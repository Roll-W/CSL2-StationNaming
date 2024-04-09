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

using Game;
using Game.Buildings;
using Game.Common;
using Game.Routes;
using Unity.Collections;
using Unity.Entities;

namespace StationNaming.System;

public partial class AutoTaggingSystem : GameSystemBase
{
    private EntityQuery _createdQuery;

    protected override void OnUpdate()
    {
        if (!Mod.GetInstance().GetSettings().Enable)
        {
            return;
        }
        if (!Mod.GetInstance().GetSettings().AutoNaming)
        {
            return;
        }

        var entities = _createdQuery.ToEntityArray(Allocator.Temp);

        foreach (var entity in entities)
        {
            EntityManager.AddComponent<ToAutoNaming>(entity);
            EntityManager.AddComponent<Selected>(entity);
        }
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        _createdQuery = GetEntityQuery(new EntityQueryDesc
        {
            All =
            [
                ComponentType.ReadOnly<Created>()
            ],
            Any =
            [
                ComponentType.ReadOnly<TransportStop>(),
                ComponentType.ReadOnly<TransportStation>(),
            ],
            None =
            [
                ComponentType.ReadOnly<Deleted>()
            ]
        });

        RequireForUpdate(_createdQuery);
    }
}