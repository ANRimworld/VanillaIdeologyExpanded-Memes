﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;
using RimWorld.Planet;

namespace VanillaMemesExpanded
{
    public class MapComponent_IdeologicalGoodies : MapComponent
    {



        public MapComponent_IdeologicalGoodies(Map map) : base(map)
        {

        }



        public override void MapComponentTick()
        {
            base.MapComponentTick();
            if (!Current.Game.GetComponent<GameComponent_IdeologicalGoodies>().sentOncePerGame)
            {

                List<Thing> things = new List<Thing>();

                foreach (StartingItemsByIdeologyDef startingItems in DefDatabase<StartingItemsByIdeologyDef>.AllDefsListForReading)
                {
                    if (Current.Game.World.factionManager.OfPlayer.ideos.PrimaryIdeo.HasMeme(startingItems.associatedMeme))
                    {
                        things = startingItems.thingSetMaker.root.Generate();
                    }

                }                
                if (things.Count > 0) { DropPodUtility.DropThingsNear(MapGenerator.PlayerStartSpot, map, things, 110); }
                
               
                Current.Game.GetComponent<GameComponent_IdeologicalGoodies>().sentOncePerGame = true;
            }


        }


    }


}

