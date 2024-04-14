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
using Game;
using Game.Common;
using Game.Objects;
using Game.Tools;
using Game.UI;
using Unity.Collections;
using Unity.Entities;
using TransportStation = Game.Buildings.TransportStation;

namespace StationNaming.System;

public partial class StationNamingSystem : GameSystemBase
{
    private EntityQuery _stationQuery;

    private NameSystem _nameSystem;
    private StopNameHelper _stopNameHelper;

    protected override void OnUpdate()
    {
        if (!Mod.GetInstance().GetSettings().Enable)
        {
            return;
        }

        var options = Mod.GetInstance().GetSettings().ToNameOptions();
        _stopNameHelper.ApplyTo(options);

        var searchDepth = Mod.GetInstance().GetSettings().SearchDepth;
        try
        {
            var stations = _stationQuery.ToEntityArray(Allocator.Temp);

            foreach (var entity in stations)
            {
                var candidates =
                    _stopNameHelper.SetCandidatesForStation(entity, searchDepth);
            }
        }
        catch (Exception e)
        {
            Mod.GetLogger().Error(e);
        }
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        _nameSystem = World.DefaultGameObjectInjectionWorld
            .GetOrCreateSystemManaged<NameSystem>();
        _stopNameHelper = new StopNameHelper(EntityManager, _nameSystem);

        _stationQuery = GetEntityQuery(new EntityQueryDesc
        {
            All =
            [
                ComponentType.ReadOnly<TransportStation>(),
            ],
            Any =
            [
                ComponentType.ReadOnly<Highlighted>(),
                ComponentType.ReadOnly<Selected>(),
                ComponentType.ReadOnly<Created>()
            ],
            None =
            [
                ComponentType.ReadOnly<Deleted>(),
                ComponentType.ReadOnly<Temp>(),
                ComponentType.ReadOnly<OutsideConnection>()
            ]
        });

        RequireForUpdate(_stationQuery);
    }

    public override int GetUpdateInterval(SystemUpdatePhase phase)
    {
        return 1;
    }

    public override int GetUpdateOffset(SystemUpdatePhase phase)
    {
        return -1;
    }
}