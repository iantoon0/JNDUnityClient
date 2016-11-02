using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [System.Serializable]
    internal class Encounter
    {
        List<EncounterActor> EncounterActors;
        List<Point> EncounterArea;
    }
}