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

using Colossal.Localization;
using Game.SceneFlow;

namespace StationNaming.Setting
{
    public static class Localizations
    {
        // TODO: generate keys using ModSettings
        private static readonly Translation[] Translations =
        [
            new Translation("Options.SECTION[StationNaming.StationNaming.Mod]")
                .AddTranslation(LocaleCode.EnUs, "Station Naming")
                .AddTranslation(LocaleCode.ZhHans, "站点命名")
                .AddTranslation(LocaleCode.ZhHant, "站點命名"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Enable]")
                .AddTranslation(LocaleCode.EnUs, "Enable Station Naming")
                .AddTranslation(LocaleCode.ZhHans, "启用站点命名")
                .AddTranslation(LocaleCode.ZhHant, "啟用站點命名"),
            new Translation("Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Enable]")
                .AddTranslation(LocaleCode.EnUs,
                    "Enable or disable station naming. When disabled, existing names will not be updated, " +
                    "and no name candidates will be generated.")
                .AddTranslation(LocaleCode.ZhHans, "在此启用或禁用站点命名。禁用时不会更新现有命名，且不会生成名称候选。")
                .AddTranslation(LocaleCode.ZhHant, "在此啟用或禁用站點命名。禁用時不會更新現有命名，且不會生成名稱候選。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.SearchDepth]")
                .AddTranslation(LocaleCode.EnUs, "Search Depth")
                .AddTranslation(LocaleCode.ZhHans, "搜索深度")
                .AddTranslation(LocaleCode.ZhHant, "搜索深度"),
            new Translation(
                    "Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.SearchDepth]")
                .AddTranslation(LocaleCode.EnUs,
                    "The maximum depth to search for name candidates, setting too high is not recommended as it may affect game performance.")
                .AddTranslation(LocaleCode.ZhHans, "搜索名称候选的最大深度，不建议设置过大，以免影响游戏性能。")
                .AddTranslation(LocaleCode.ZhHant, "搜索名稱候選的最大深度，不建議設置過大，以免影響遊戲性能。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.IntersectionNamingFormat]")
                .AddTranslation(LocaleCode.EnUs, "Intersection Naming Format")
                .AddTranslation(LocaleCode.ZhHans, "交叉口命名格式")
                .AddTranslation(LocaleCode.ZhHant, "交叉口命名格式"),
            new Translation(
                    "Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.IntersectionNamingFormat]")
                .AddTranslation(LocaleCode.EnUs,
                    "The format used when generating the name of the intersection source, " +
                    "in addition to the dropdown items, the format can be changed by modifying the settings file. " +
                    "The road order can be reversed by setting.")
                .AddTranslation(LocaleCode.ZhHans, "在生成交叉口来源的名称时使用的格式，除下拉项以外还可通过修改设置文件变更格式。{0} 表示当前道路，{1} 表示交叉道路。可通过设置反转道路顺序。")
                .AddTranslation(LocaleCode.ZhHant, "在生成交叉口來源的名稱時使用的格式，除下拉項以外還可通過修改設置文件變更格式。{0} 表示當前道路，{1} 表示交叉道路。可通過設置反轉道路順序。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.ReverseRoadOrder]")
                .AddTranslation(LocaleCode.EnUs, "Reverse Road Order")
                .AddTranslation(LocaleCode.ZhHans, "反转道路顺序")
                .AddTranslation(LocaleCode.ZhHant, "反轉道路順序"),
            new Translation("Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.ReverseRoadOrder]")
                .AddTranslation(LocaleCode.EnUs,
                    "Reverse the order of the road, swap {0} and {1} in the intersection naming format.")
                .AddTranslation(LocaleCode.ZhHans, "反转道路顺序，使交叉口命名格式中的 {0} 和 {1} 交换位置。")
                .AddTranslation(LocaleCode.ZhHant, "反轉道路順序，使交叉口命名格式中的 {0} 和 {1} 交換位置。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Prefix]")
                .AddTranslation(LocaleCode.EnUs, "Prefix")
                .AddTranslation(LocaleCode.ZhHans, "前缀")
                .AddTranslation(LocaleCode.ZhHant, "前綴"),
            new Translation("Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Prefix]")
                .AddTranslation(LocaleCode.EnUs, "The prefix to be added to the station name.")
                .AddTranslation(LocaleCode.ZhHans, "要添加到站点名称的前缀。")
                .AddTranslation(LocaleCode.ZhHant, "要添加到站點名稱的前綴。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Suffix]")
                .AddTranslation(LocaleCode.EnUs, "Suffix")
                .AddTranslation(LocaleCode.ZhHans, "后缀")
                .AddTranslation(LocaleCode.ZhHant, "後綴"),
            new Translation("Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.Suffix]")
                .AddTranslation(LocaleCode.EnUs, "The suffix to be added to the station name.")
                .AddTranslation(LocaleCode.ZhHans, "要添加到站点名称的后缀。")
                .AddTranslation(LocaleCode.ZhHant, "要添加到站點名稱的後綴。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.AutoUpdate]")
                .AddTranslation(LocaleCode.EnUs, "Auto Update Name")
                .AddTranslation(LocaleCode.ZhHans, "自动更新站名")
                .AddTranslation(LocaleCode.ZhHant, "自動更新站名"),
            new Translation(
                    "Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.AutoUpdate]")
                .AddTranslation(LocaleCode.EnUs,
                    "When enabled, the station name will be automatically updated based on the selected name source.")
                .AddTranslation(LocaleCode.ZhHans, "启用后，将根据所选的命名来源自动更新站点名称。")
                .AddTranslation(LocaleCode.ZhHant, "啟用後，將根據所選的命名來源自動更新站點名稱。"),
            new Translation("Options.OPTION[StationNaming.StationNaming.Mod.StationNamingSettings.AutoNaming]")
                .AddTranslation(LocaleCode.EnUs, "Auto Naming")
                .AddTranslation(LocaleCode.ZhHans, "自动命名")
                .AddTranslation(LocaleCode.ZhHant, "自動命名"),
            new Translation(
                    "Options.OPTION_DESCRIPTION[StationNaming.StationNaming.Mod.StationNamingSettings.AutoNaming]")
                .AddTranslation(LocaleCode.EnUs,
                    "When enabled, the station will be automatically named when created. " +
                    "Named according to the order of the owner and the current road.")
                .AddTranslation(LocaleCode.ZhHans, "启用后，自动为新建的站点命名。按照所有者、当前道路的顺序命名。")
                .AddTranslation(LocaleCode.ZhHant, "啟用後，自動為新建的站點命名。按照所有者、當前道路的順序命名。"),

            new Translation("Options.GROUP[StationNaming.StationNaming.Mod.Experimental]")
                .AddTranslation(LocaleCode.EnUs, "Experimental")
                .AddTranslation(LocaleCode.ZhHans, "实验性")
                .AddTranslation(LocaleCode.ZhHant, "實驗性"),
            new Translation("Options.GROUP_DESCRIPTION[StationNaming.StationNaming.Mod.Experimental]")
                .AddTranslation(LocaleCode.EnUs, "Experimental features, may cause game instability")
                .AddTranslation(LocaleCode.ZhHans, "实验性功能，可能会导致游戏不稳定")
                .AddTranslation(LocaleCode.ZhHant, "實驗性功能，可能會導致遊戲不穩定"),


            new Translation("StationNaming.NameCandidates")
                .AddTranslation(LocaleCode.EnUs, "Name Candidates")
                .AddTranslation(LocaleCode.ZhHans, "名称候选")
                .AddTranslation(LocaleCode.ZhHant, "名稱候選"),
            new Translation("StationNaming.NameCandidates[Tooltip]")
                .AddTranslation(LocaleCode.EnUs, "Here are all the name candidates, you can select them to replace the existing name.")
                .AddTranslation(LocaleCode.ZhHans, "这里是所有的名称候选，您可以选择它们来替换现有名称。")
                .AddTranslation(LocaleCode.ZhHant, "這裡是所有的名稱候選，您可以選擇它們來替換現有名稱。"),
            new Translation("StationNaming.Candidates")
                .AddTranslation(LocaleCode.EnUs, "Candidates")
                .AddTranslation(LocaleCode.ZhHans, "候选列表")
                .AddTranslation(LocaleCode.ZhHant, "候選列表"),

            new Translation("StationNaming.NameSource[Building]")
                .AddTranslation(LocaleCode.EnUs, "Building")
                .AddTranslation(LocaleCode.ZhHans, "一般建筑")
                .AddTranslation(LocaleCode.ZhHant, "一般建築"),
            new Translation("StationNaming.NameSource[Road]")
                .AddTranslation(LocaleCode.EnUs, "Road")
                .AddTranslation(LocaleCode.ZhHans, "道路")
                .AddTranslation(LocaleCode.ZhHant, "道路"),
            new Translation("StationNaming.NameSource[Intersection]")
                .AddTranslation(LocaleCode.EnUs, "Intersection")
                .AddTranslation(LocaleCode.ZhHans, "交叉口")
                .AddTranslation(LocaleCode.ZhHant, "交叉口"),
            new Translation("StationNaming.NameSource[Owner]")
                .AddTranslation(LocaleCode.EnUs, "Owner")
                .AddTranslation(LocaleCode.ZhHans, "所有者")
                .AddTranslation(LocaleCode.ZhHant, "所有者"),
            new Translation("StationNaming.NameSource[TransportStation]")
                .AddTranslation(LocaleCode.EnUs, "Transport Station")
                .AddTranslation(LocaleCode.ZhHans, "交通站点")
                .AddTranslation(LocaleCode.ZhHant, "交通站點"),
            new Translation("StationNaming.NameSource[TransportDepot]")
                .AddTranslation(LocaleCode.EnUs, "Transport Depot")
                .AddTranslation(LocaleCode.ZhHans, "交通车库")
                .AddTranslation(LocaleCode.ZhHant, "交通車庫"),
            new Translation("StationNaming.NameSource[ZoneBuilding]")
                .AddTranslation(LocaleCode.EnUs, "Zone Building")
                .AddTranslation(LocaleCode.ZhHans, "分区建筑")
                .AddTranslation(LocaleCode.ZhHant, "區域建築"),
            new Translation("StationNaming.NameSource[SignatureBuilding]")
                .AddTranslation(LocaleCode.EnUs, "Signature Building")
                .AddTranslation(LocaleCode.ZhHans, "标志性建筑")
                .AddTranslation(LocaleCode.ZhHant, "標誌性建築"),
            new Translation("StationNaming.NameSource[School]")
                .AddTranslation(LocaleCode.EnUs, "School")
                .AddTranslation(LocaleCode.ZhHans, "学校")
                .AddTranslation(LocaleCode.ZhHant, "學校"),
            new Translation("StationNaming.NameSource[FireStation]")
                .AddTranslation(LocaleCode.EnUs, "Fire Station")
                .AddTranslation(LocaleCode.ZhHans, "消防站")
                .AddTranslation(LocaleCode.ZhHant, "消防站"),
            new Translation("StationNaming.NameSource[PoliceStation]")
                .AddTranslation(LocaleCode.EnUs, "Police Station")
                .AddTranslation(LocaleCode.ZhHans, "警察局")
                .AddTranslation(LocaleCode.ZhHant, "警察局"),
            new Translation("StationNaming.NameSource[Hospital]")
                .AddTranslation(LocaleCode.EnUs, "Hospital")
                .AddTranslation(LocaleCode.ZhHans, "医院")
                .AddTranslation(LocaleCode.ZhHant, "醫院"),
            new Translation("StationNaming.NameSource[Park]")
                .AddTranslation(LocaleCode.EnUs, "Park")
                .AddTranslation(LocaleCode.ZhHans, "公园")
                .AddTranslation(LocaleCode.ZhHant, "公園"),
            new Translation("StationNaming.NameSource[CityService]")
                .AddTranslation(LocaleCode.EnUs, "City Service")
                .AddTranslation(LocaleCode.ZhHans, "城市服务")
                .AddTranslation(LocaleCode.ZhHant, "城市服務"),
            new Translation("StationNaming.NameSource[Unknown]")
                .AddTranslation(LocaleCode.EnUs, "Unknown")
                .AddTranslation(LocaleCode.ZhHans, "未知")
                .AddTranslation(LocaleCode.ZhHant, "未知"),
        ];

        public static void LoadTranslations()
        {
            foreach (var supportedLocale in GameManager.instance
                         .localizationManager.GetSupportedLocales())
            {
                var locale = FromString(supportedLocale);
                var dictionary = Translation.ToDictionary(Translations, locale);
                GameManager.instance.localizationManager.AddSource(
                    supportedLocale, new MemorySource(dictionary)
                );
            }
        }

        private static LocaleCode FromString(string code)
        {
            return code switch
            {
                "en-US" => LocaleCode.EnUs,
                "zh-HANS" => LocaleCode.ZhHans,
                "zh-HANT" => LocaleCode.ZhHant,
                _ => LocaleCode.EnUs
            };
        }
    }
}