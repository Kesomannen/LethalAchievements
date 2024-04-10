﻿using LethalAchievements.Config.Serialization;
using Newtonsoft.Json;
using static LethalAchievements.Config.ConditionHelper;

namespace LethalAchievements.Config.Conditions;

/// <summary>
///     Checks properties about the current moon.
/// </summary>
public class MoonCondition : ICondition
{
    /// <summary>
    ///     The moons to check for. If you specify multiple, any of them will match.
    /// </summary>
    [JsonConverter(typeof(OneOrMultipleConverter))]
    public string[]? Name;
    
    /// <summary>
    ///     The weather types to check for. If you specify multiple, any of them will match.
    /// </summary>
    [JsonConverter(typeof(OneOrMultipleConverter))]
    public LevelWeatherType[]? Weather;
    
    /// <summary>
    ///     The parts of the day to check for.
    ///     This corresponds to the icons shown at the top of the HUD.
    ///     On the company moon, this is set to None.
    ///     If you specify multiple, any of them will match.
    /// </summary>
    [JsonConverter(typeof(OneOrMultipleConverter))]
    public DayMode[]? DayMode;

    /// <inheritdoc />
    public bool Evaluate(in Context context) 
    {
        return All(
            Contains(TimeOfDay.Instance.currentLevel.PlanetName, Name),
            Contains(TimeOfDay.Instance.currentLevelWeather, Weather),
            Contains(TimeOfDay.Instance.dayMode, DayMode)
        );
    }
}