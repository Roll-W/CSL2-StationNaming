﻿// Copyright (c) 2024 RollW
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Text;
using Game.Prefabs;
using Game.SceneFlow;
using Game.UI;
using StationNaming.System;
using Unity.Collections;
using Unity.Entities;
using static System.String;

namespace StationNaming.Setting;

public class NameFormatter(
    EntityManager entityManager,
    NameSystem nameSystem,
    PrefabSystem prefabSystem)
{
    public NameOptions Options { get; set; } = new();

    public string FormatRefers(
        IList<NameSourceRefer> refers,
        Entity targetEntity,
        TargetType targetType = TargetType.None)
    {
        var count = refers.Count;
        string referFormat;
        switch (count)
        {
            case 0:
                return "";
            case 1 when refers[0].Source == NameSource.Owner:
                return refers[0].GetName(entityManager, nameSystem);
            case 2:
                referFormat = LegacyFormatRefers(refers[0], refers[1]);
                break;
            default:
                referFormat = StdFormatRefers(refers);
                break;
        }

        var targetFormat = Options.TargetFormats[targetType];
        var prefabName = GetPrefabName(targetEntity, targetFormat.IsAnyPrefab());

        return targetFormat.Format(
            referFormat,
            prefabName: prefabName,
            hasNext: false
        );
    }

    private string StdFormatRefers(IList<NameSourceRefer> refers)
    {
        StringBuilder builder = new();

        ForeachRefers(refers, Options.Reverse, (refer, hasNext) =>
        {
            var format = Options.SourceFormats[refer.Source];
            var name = refer.GetName(entityManager, nameSystem);
            builder.Append(format.Format(name, hasNext: hasNext));
        });

        return builder.ToString();
    }

    private static void ForeachRefers(
        IList<NameSourceRefer> refers,
        bool reverse,
        Action<NameSourceRefer, bool> action)
    {
        var count = refers.Count;
        for (var i = 0; i < count; i++)
        {
            var refer = reverse ? refers[count - i - 1] : refers[i];
            var hasNext = i < count - 1;
            action(refer, hasNext);
        }
    }

    private string LegacyFormatRefers(
        NameSourceRefer refer1, NameSourceRefer refer2)
    {
        var settings = Mod.GetInstance().GetSettings();

        var first = refer1.GetName(entityManager, nameSystem);
        var second = refer2.GetName(entityManager, nameSystem);

        var namingFormat = settings.IntersectionNamingFormat;

        return settings.ReverseRoadOrder
            ? Format(namingFormat, second, first)
            : Format(namingFormat, first, second);
    }

    private string GetPrefabName(Entity entity, bool prefab)
    {
        if (!prefab)
        {
            return "";
        }

        var prefabEntity = GetPrefabEntity(entity);
        if (prefabEntity == Entity.Null)
        {
            return "";
        }

        var prefabName = prefabSystem.GetPrefabName(prefabEntity);
        var prefabKey = "Assets.NAME[" + prefabName + "]";

        var localizationManager = GameManager.instance.localizationManager;

        return localizationManager.activeDictionary.TryGetValue(prefabKey, out var localized)
            ? localized
            : prefabName;
    }

    private Entity GetPrefabEntity(Entity entity)
    {
        return entityManager.HasComponent<PrefabRef>(entity)
            ? entityManager.GetComponentData<PrefabRef>(entity).m_Prefab
            : Entity.Null;
    }

    public string FormatRefers(
        INativeList<NameSourceRefer> refers,
        Entity targetEntity,
        TargetType targetType = TargetType.None
    )
    {
        List<NameSourceRefer> copy = [];
        for (var i = 0; i < refers.Length; i++)
        {
            copy.Add(refers[i]);
        }

        return FormatRefers(copy, targetEntity, targetType);
    }
}