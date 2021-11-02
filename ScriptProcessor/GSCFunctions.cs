using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    public static class GSCFunctions
    {
        #region anim
        /// <summary>
        /// Queries the given animation for a note track.
        /// </summary>
        /// <param name="animation">An animation.</param>
        /// <param name="noteTrackName">Name of a note track.</param>
        /// <example>
        /// <code lang="c#">
        ///     <![CDATA[
        ///     if (AnimHasNoteTrack(facialanim, "dialogue"))
        ///     {
        ///         // ...
        ///     }
        ///     ]]>
        /// </code>
        /// </example>
        public static bool AnimHasNoteTrack(string animation, string noteTrackName)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.animhasnotetrack, animation, noteTrackName);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets the rotation difference in an <see cref="Animation"/>.
        /// </summary>
        /// <param name ="animation">An animation.</param>
        /// <param name="startTime">Starting time.</param>
        /// <param name="endTime">Ending time.</param>
        /// <returns>Returns the rotation difference in the given animation.</returns>
        public static float GetAngleDelta(string animation, float startTime = 0f, float endTime = 1f)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getangledelta, animation, startTime, endTime);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the length of an <see cref="Animation"/>.
        /// </summary>
        /// <param name="primitiveAnimation">A primitive animation.</param>
        /// <returns>Returns the length of the given animation.</returns>
        public static float GetAnimLength(string primitiveAnimation)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getanimlength, primitiveAnimation);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the movement vector difference in an <see cref="Animation"/>.
        /// </summary>
        /// <param name="animation">An animation.</param>
        /// <param name="startTime">Starting time.</param>
        /// <param name="endTime">Ending time.</param>
        /// <returns>Returns the movement vector difference of the given animation.</returns>
        public static float GetMoveDelta(string animation, float startTime = 0f, float endTime = 1f)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getmovedelta, animation, startTime, endTime);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets an array of the times during an <see cref="Animation"/> that the given NoteTrack occurs.
        /// </summary>
        /// <param name="animation">An animation.</param>
        /// <param name="noteTrackName">A NoteTrack name.</param>
        /// <returns>Returns an array containing the times where the NoteTrack occurs.</returns>
        public static Array GetNoteTrackTimes(string animation, string noteTrackName)
        {
            //GameInterface.Utils.GlobalCall("getnotetracktimes", animation, noteTrackName);

            //Array ret = GameInterface.Utils.ScriptStack.PeekFloat(0);
            //return ret;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of bones in an xModel.
        /// </summary>
        /// <param name="model">An xModel name.</param>
        /// <returns>Returns the amount of bones within an xModel.</returns>
        public static int GetNumParts(string model)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getnumparts, model);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the name of a part of a model.
        /// </summary>
        /// <param name="model">An xModel name.</param>
        /// <param name="index">The bone index (must be less than the total amount of bones).</param>
        /// <returns>Returns the name of the indexth bone.</returns>
        public static string GetPartName(string model, int index)
        {
            ////Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getpartname, model, index);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the angles of a particular tag of this model.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns>Returns the angle of the given tag</returns>
        public static Vector3 GetTagAngles(this Entity entity, string tagName)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.gettagangles, tagName);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the origin of a particular tag of this model.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns>Returns the origin of the given tag</returns>
        public static Vector3 GetTagOrigin(this Entity entity, string tagName)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.gettagorigin, tagName);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Plays an <see cref="Animation"/> on this entity
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static void ScriptModelPlayAnim(this Entity entity, string animation)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scriptmodelplayanim, animation);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clears this entity's current animation
        /// </summary>
        /// <returns></returns>
        public static void ScriptModelClearAnim(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scriptmodelclearanim);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the animation of a corpse
        /// </summary>
        /// <returns>Returns the name of the anim used by this corpse</returns>
        public static string GetCorpseAnim(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcorpseanim);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion

        #region client
        /// <summary>
        /// Prints the given string to all clients.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void AllClientsPrint(string message)
        {
            //Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.allclientsprint, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether the player can spectate the given team.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="canSpectate"></param>
        /// <returns></returns>
        public static void AllowSpectateTeam(this Entity entref, string team, bool canSpectate)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.allowspectateteam, team, canSpectate);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sends an announcement to all clients.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Announcement(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.announcement, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Bans the specified player.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        //public static void Ban(this Entity entref)
        //{
        //throw new NotImplementedException();
        //}NOTE: Unseen in IS

        /// <summary>
        /// Causes the player to begin selecting a location. A map HUD element should be visible for them to see where they're selecting.
        /// When the user confirms or cancels, they will recieve a "confirm_location" or "cancel_location". The former notify contains the location they selected, as a Vector3.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="locationSelector"></param>
        /// <returns></returns>
        public static void BeginLocationSelection(this Entity entref, string locationSelector)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.beginlocationselection, locationSelector);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Causes the player to begin selecting a location. A map HUD element should be visible for them to see where they're selecting.
        /// When the user confirms or cancels, they will recieve a "confirm_location" or "cancel_location". The former notify contains the location they selected, as a Vector3.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="locationSelector"></param>
        /// <param name="selectorSize"></param>
        /// <returns></returns>
        public static void BeginLocationSelection(this Entity entref, string locationSelector, bool directionality, int selectorSize)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.beginlocationselection, locationSelector, directionality, selectorSize);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sends an announcement to a single client.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void ClientAnnouncement(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.clientannouncement, entref, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Print a localized version of this string for a given client.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void ClientPrint(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.clientprint, entref, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clone the player's model for death animations.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="duration"></param>
        /// <returns>Returns the cloned player model as an Entity</returns>
        public static Entity ClonePlayer(this Entity entref, int duration = -1)
        {
            Function.SetEntRef(entref.EntRef);
            if (duration != -1) Function.Call(ScriptNames.FunctionList.cloneplayer, duration);
            else Function.Call(ScriptNames.FunctionList.cloneplayer);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Disable the player's weapon.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void DisableWeapons(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Drop an item with the given item name.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="itemName"></param>
        /// <returns>Returns the dropped item as an Entity</returns>
        public static Entity DropItem(this Entity entref, string itemName)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.dropitem, itemName);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Enable the player's weapon.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void EnableWeapons(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Causes the player to leave location selection mode.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void EndLocationSelection(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.endlocationselection);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Get the viewmodel name for the given player.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns>Returns the model name of the given player's viewmodel</returns>
        public static string GetViewmodel(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.getviewmodel);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Returns true if the player is mantling, false otherwise.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns>Returns a bool of whether the player is mantling</returns>
        public static bool IsMantling(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.ismantling);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the player is on a ladder, false otherwise.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns>Returns a bool of whether the player is on a ladder or not</returns>
        public static bool IsOnLadder(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.isonladder);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the given int is a valid client number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns a bool of whether the int is a valid client number or not</returns>
        public static bool IsPlayerNumber(this Entity entity, int number)
        {
            /* Non-call func, should use call instead
             * if (number < 17 && number >= 0)
             *     return true;
             * else return false;
             */
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isplayernumber, entity, number);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the entity is a ragdoll body, false otherwise.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns>Returns a bool of whether the given entity is a ragdoll body or not</returns>
        public static bool IsRagdoll(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.isragdoll);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the player is talking via voice chat.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns>Returns a bool of whether the given player is talking or not via voice chat</returns>
        public static bool IsTalking(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.istalking);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Kicks the specified player.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void Kick(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.kick, entref);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Flags a Dvar with the DVAR_CODINFO flag.
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void MakeDvarServerInfo(string dvar, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makedvarserverinfo, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a client chat message from this client to everybody.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void SayAll(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.sayall, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a client chat message from this client to everybody on their team.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void SayTeam(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.sayteam, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the player's rank and prestige level.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="rank"></param>
        /// <param name="prestige"></param>
        /// <returns></returns>
        public static void SetRank(this Entity entref, int rank, int? prestige = null)
        {
            //if (prestige == -1) prestige = Entity.GetField<int>("pers")["prestige"];
            Function.SetEntRef(entref.EntRef);
            if (prestige != null)  Function.Call(ScriptNames.FunctionList.setrank, rank, prestige);
            else Function.Call(ScriptNames.FunctionList.setrank, rank);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the weapon that this player will spawn with.
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void SetSpawnWeapon(this Entity entref, string weapon)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.setspawnweapon, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the team that this trigger will react to
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void SetTeamForTrigger(Entity trigger, string team)
        {
            Function.SetEntRef(trigger.EntRef);
            Function.Call(ScriptNames.FunctionList.setteamfortrigger, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Updates the scoreboard data on a given client.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void ShowScoreBoard(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.showscoreboard);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Begin ragdoll physics for this entity. Does nothing if the entity is already a ragdoll.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void StartRagdoll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startragdoll);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Kills the player immediately as a suicide.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void Suicide(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.suicide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Updates the client's knowledge of scores for theirself and the (next) best player in the game. For use in Free-For-All.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void UpdateDMScores(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.updatedmscores);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Updates the client's knowledge of team scores.
        /// </summary>
        /// <param name="entref"></param>
        /// <returns></returns>
        public static void UpdateScores(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.updatescores);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region dmg
        /// <summary>
        /// Does damage to the player
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="inflictor"></param>
        /// <param name="attacker"></param>
        /// <param name="damage"></param>
        /// <param name="damageFlags"></param>
        /// <param name="meansOfDeath"></param>
        /// <param name="weapon"></param>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        /// <param name="hitLocation"></param>
        /// <param name="offsetTime"></param>
        /// <returns></returns>
        public static void FinishPlayerDamage(this Entity entref, Entity inflictor, Entity attacker, int damage, int damageFlags, string meansOfDeath, string weapon, Vector3 point, Vector3 direction, string hitLocation, float offsetTime)
        {
            Function.SetEntRef(entref.EntRef);
            if (inflictor == null && attacker != null) Function.Call(ScriptNames.FunctionList.finishplayerdamage, string.Empty, attacker, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else if (attacker == null && inflictor != null) Function.Call(ScriptNames.FunctionList.finishplayerdamage, inflictor, string.Empty, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else if (attacker == null && inflictor == null) Function.Call(ScriptNames.FunctionList.finishplayerdamage, string.Empty, string.Empty, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else Function.Call(ScriptNames.FunctionList.finishplayerdamage, inflictor, attacker, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="range"></param>
        /// <param name="maxDamage"></param>
        /// <param name="minDamage"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static void GlassRadiusDamage(Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker = null)
        {
            if (attacker == null)
                Function.Call(ScriptNames.FunctionList.glassradiusdamage, origin, range, maxDamage, minDamage);
            else
                Function.Call(ScriptNames.FunctionList.glassradiusdamage, origin, range, maxDamage, minDamage, attacker);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Does damage to all damageable objects within a given radius. The amount of damage is linear according to how close the object is to the radius.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="range"></param>
        /// <param name="maxDamage"></param>
        /// <param name="minDamage"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static void RadiusDamage(Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker = null, string mod = "", string weapon = "")
        {
            if (attacker == null && mod == "" && weapon == "")
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage);
            else if (mod == "" && weapon == "")
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage, attacker);
            else if (weapon == "")
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage, attacker, mod);
            else
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage, attacker, mod, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Does damage to all damageable objects within a given radius from this entity. The amount of damage is linear according to how close the object is to the radius.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="range"></param>
        /// <param name="maxDamage"></param>
        /// <param name="minDamage"></param>
        /// <param name="attacker"></param>
        /// <param name="meansOfDeath"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void RadiusDamage(this Entity entity, Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker, string meansOfDeath, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_radiusdamage, origin, range, maxDamage, minDamage, attacker, meansOfDeath, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the 'candamage' flag for this entity. This means that it can respond to notifies from bullets and grenade hits.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="canDamage"></param>
        /// <returns></returns>
        public static void SetCanDamage(this Entity entity, bool canDamage)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcandamage, canDamage);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the 'canradiusdamage' flag for this entity. This means that it can respond to notifies from explosions and radius damages.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="canRadiusDamage"></param>
        /// <returns></returns>
        public static void SetCanRadiusDamage(this Entity entity, bool canDamage)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcanradiusdamage, canDamage);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether the player should ignore radius damage or not
        /// </summary>
        /// <param name="entref"></param>
        /// <param name="ignoreRadiusDamage"></param>
        /// <returns></returns>
        public static void SetPlayerIgnoreRadiusDamage(bool ignoreRadiusDamage)
        {
            //Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerignoreradiusdamage, ignoreRadiusDamage);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the passed in means of death is an explosive damage
        /// </summary>
        /// <param name="mod"></param>
        /// <returns>Returns true if the given means of death is an explosive damage</returns>
        public static bool IsExplosiveDamageMOD(string mod)
        {
            Function.Call(ScriptNames.FunctionList.isexplosivedamagemod, mod);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region debug
        /// <summary>
        /// Adds a test client to the map and returns a reference to that client.
        /// </summary>
        /// <returns>Returns the test client as an <see cref="Entity"/></returns>
        public static Entity AddTestClient()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addtestclient);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Assert that the given statement is correct. The function will throw a script error if this is false.
        /// </summary>
        /// <param name ="value">The statement to be correct.</param>
        /// <returns></returns>
        public static void Assert(bool value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.assert, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Assert that the gven statement is correct. The function will throw a script error if this is false, with the given message.
        /// </summary>
        /// <param name ="value">The statement to be correct</param>
        /// <param name ="message">Error message</param>
        /// <returns></returns>
        public static void AssertEx(bool value, string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.assertex, value, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Throws a script error with the given message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void AssertMsg(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.assertmsg, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a line to the screen.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void IPrintLn(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.iprintln, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a bold line to the screen.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void IPrintLnBold(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.iprintlnbold, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Draw a debug line on screen.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="color"></param>
        /// <param name="depthTest"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static void Line(Vector3 start, Vector3 end, Vector3? color = null, bool depthTest = false, int duration = 0)
        {
            if (color == null) color = Vector3.Zero;
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.line, start, end, color, depthTest, duration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Print(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.print, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Draw 3d text on screen
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <param name="scale"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static void Print3d(Vector3 origin, string text, Vector3 color)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha, float scale)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha, float scale, int duration)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha, scale, duration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a line to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void PrintLn(string message)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.println, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the current print channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns>Returns the previous print channel</returns>
        public static string SetPrintChannel(string channel)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setprintchannel, channel);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Enables or disables no clip for this player
        /// </summary>
        /// <param name="noclip"></param>
        /// <returns></returns>
        public static void NoClip(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.noclip);
        }//Removed in IW5 1.5

        /// <summary>
        /// Enables or disables ufo mode for this player
        /// </summary>
        /// <param name="ufo"></param>
        /// <returns></returns>
        public static void Ufo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ufo);
        }//Removed in IW5 1.5

        /// <summary>
        /// Gets the game's current build version
        /// </summary>
        /// <returns>Returns the game's current build version number</returns>
        public static float GetBuildVersion()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getbuildversion);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the game's current build number
        /// </summary>
        /// <returns>Returns the game's current build number</returns>
        public static float GetBuildNumber()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getbuildnumber);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the host's system's current time
        /// </summary>
        /// <returns>Returns the host's system's current time</returns>
        public static int GetSystemTime()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getsystemtime);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Opens a print channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static void CreatePrintChannel(string channel)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.createprintchannel, channel);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region dvar
        /// <summary>
        /// Gets the value of a dvar as a string.
        /// </summary>
        /// <param name="dvar"></param>
        /// <returns>Returns the value of the given dvar as a string</returns>
        public static string GetDvar(string dvar)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getdvar, dvar);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the value of a dvar as a float.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns the value of the given dvar as a float</returns>
        public static float GetDvarFloat(string dvar)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getdvarfloat, dvar);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the value of a dvar as an integer.
        /// </summary>
        /// <param name="dvar"></param>
        /// <returns>Returns the value of the given dvar as an int</returns>
        public static int GetDvarInt(string dvar)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getdvarint, dvar);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the value of a script dvar. Cannot set code dvars.
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetDvar(string dvar, Parameter value)
        {
            ////Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdvar, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a dynamic dvar
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetDynamicDvar(string dvar, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdynamicdvar, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a dvar, only if the dvar has not been created yet
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetDvarIfUninitialized(string dvar, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdvarifuninitialized, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a developer dvar
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetDevDvar(string dvar, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdevdvar, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a dev dvar, only if the dvar has not been created yet
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetDevDvarIfUninitialized(string dvar, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdevdvarifuninitialized, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a Dvar as a vector
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns>Gets the dvar value as a <see cref="Vector3"/></returns>
        public static Vector3 GetDvarVector(string dvar)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getdvarvector, dvar);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion

        #region effects
        /// <summary>
        /// Load the given effect
        /// </summary>
        /// <param name="effect"></param>
        /// <returns>Returns the ID of the loaded effect</returns>
        public static int LoadFX(string effect)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.loadfx, effect);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the players' naked-eye vision. Optionally give a transition time from the current vision.
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="transitionTime"></param>
        /// <returns></returns>
        public static void VisionSetNaked(string vision)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnaked, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetNaked(string vision, int transitionTime)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnaked, vision, transitionTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the vision preset to use for players' night vision view.
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="transitionTime"></param>
        /// <returns></returns>
        public static void VisionSetNight(string vision)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnight, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetNight(string vision, int transitionTime)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnight, vision, transitionTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play this effect
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="position"></param>
        /// <param name="forward"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public static void PlayFX(int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            //Function.SetEntRef(entity.EntRef);
            if (forward != null && up != null) Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward, up);
            else if (forward != null && up == null) Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward);
            else Function.Call(ScriptNames.FunctionList.playfx, effect, position);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static Entity PlayFX_Ret(int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            //Function.SetEntRef(entity.EntRef);
            if (forward != null && up != null) Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward, up);
            else if (forward != null && up == null) Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward);
            else Function.Call(ScriptNames.FunctionList.playfx, effect, position);

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Play this effect on the entity and tag.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void PlayFXOnTag(int effect, Entity entity, string tag)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playfxontag, effect, entity, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stop this effect on the entity and tag.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void StopFXOnTag(int effect, Entity entity, string tag)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopfxontag, effect, entity, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play this effect on the entity and tag for a specific client.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static void PlayFXOnTagForClients(int effect, Entity entity, string tag, Entity client)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playfxontagforclients, effect, entity, tag, client);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the vision preset for players while they are controlling a missile
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetMissileCam(string vision)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecam, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetMissileCam(string vision, float fade)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecam, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the vision preset for players while they are scoped into a thermal scope
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetThermal(string vision)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermal, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetThermal(string vision, float fade)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermal, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the vision preset for players while they are in pain/near death
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetPain(string vision)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpain, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetPain(string vision, float fade)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpain, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the players' naked-eye vision. Optionally give a transition time from the current vision.
        /// </summary>
        /// <param name="blur"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetBlurForPlayer(this Entity entity, float blur, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setblurforplayer, blur, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays an effect and loops it at the given origin for the given time value
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="time"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Entity PlayLoopedFX(int effect, float time, Vector3 origin, int offset = 0, Vector3? forward = null, Vector3? up = null)
        {
            //Function.SetEntRef(entity.EntRef);
            if (forward == null && up == null) Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset);
            else if (up == null) Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset, forward);
            else if (forward == null) Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset, forward, up);
            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Create an effect entity that can be re-triggered efficiently at arbitrary intervals. This doesn't play the effect. Use delete to free it when done.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="position"></param>
        /// <param name="forward"></param>
        /// <param name="up"></param>
        /// <returns>Returns the spawned effect as an <see cref="Entity">Entity</see>"/></returns>
        public static Entity SpawnFX(int effect, Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position);
            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        public static Entity SpawnFX(int effect, Vector3 position, Vector3 forward)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position, forward);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        public static Entity SpawnFX(int effect, Vector3 position, Vector3 forward, Vector3 up)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position, forward, up);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Replays the effect associated with the effect entity. This does not kill any existing effects.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="when"></param>
        /// <returns></returns>
        public static void TriggerFX(Entity effect)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.triggerfx, effect);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Replays the effect associated with the effect entity. This does not kill any existing effects.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="when"></param>
        /// <returns></returns>
        public static void TriggerFX(Entity effect, float when)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.triggerfx, effect, when);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region entity
        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <returns></returns>
        public static void Delete(this Entity entity)
        {
            if (!Utilities.isEntDefined(entity)) return;
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.delete);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Causes a grenade to explode. Must be called on a grenade.
        /// </summary>
        /// <returns></returns>
        public static void Detonate(this Entity entity, Entity newAttacker = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (newAttacker == null)
                Function.Call(ScriptNames.FunctionList.detonate);
            else
                Function.Call(ScriptNames.FunctionList.detonate, newAttacker);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disables aim assist on an entity. The entity must have a brush model.
        /// </summary>
        /// <returns></returns>
        public static void DisableAimAssist(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableaimassist);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables aim assist on an entity. The entity must have a brush model.
        /// </summary>
        /// <returns></returns>
        public static void EnableAimAssist(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableaimassist);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Looks up an entity by key and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the entity found with the given key and name if any</returns>
        public static Entity GetEnt(string name, string key)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getent, name, key);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets an array of entities that have the given key, name pair
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the entities found with the given key and name in a <see cref="Array">Array</see>"/></returns>
        public static Entity GetEntArray(string name = "", string key = "")
        {
            Function.SetEntRef(-1);
            if (name == "" && key == "") Function.Call(ScriptNames.FunctionList.getentarray);
            else Function.Call(ScriptNames.FunctionList.getentarray, name, key);

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets an entity from its entity number
        /// </summary>
        /// <param name="entNum"></param>
        /// <returns>Returns the entity of the given entity number</returns>
        public static Entity GetEntByNum(int entNum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentbynum, entNum);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get the entity number of this entity
        /// </summary>
        /// <returns>Returns the entity number of the given entity</returns>
        public static int GetEntityNumber(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentitynumber);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the normal health of this entity
        /// </summary>
        /// <returns>Returns the normal health value of this entity</returns>
        public static int GetNormalHealth(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalhealth);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the origin of an entity
        /// </summary>
        /// <returns>Returns the origin of the given entity</returns>
        public static Vector3 GetOrigin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getorigin);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Hides a visible entity
        /// </summary>
        /// <returns></returns>
        public static void Hide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Hide part of an entity
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void HidePart(this Entity entity, string tag, string model = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (model != "") Function.Call(ScriptNames.FunctionList.hidepart, tag, model);
            else Function.Call(ScriptNames.FunctionList.hidepart, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks whether the entity is touching the passed in entity or trigger
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns true if the entity is touching the passed in entity/trigger</returns>
        public static bool IsTouching(this Entity ent, Entity entity)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.istouching, entity);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Turns off entity's laser sight
        /// </summary>
        /// <returns></returns>
        public static void LaserOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseroff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on entity's laser sight
        /// </summary>
        /// <returns></returns>
        public static void LaserOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseron);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches one entity to another
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="originOffset"></param>
        /// <param name="anglesOffset"></param>
        /// <returns></returns>
        public static void LinkTo(this Entity ent, Entity entity, string tag = "", Vector3? originOffset = null, Vector3? anglesOffset = null)
        {
            Function.SetEntRef(ent.EntRef);
            if (tag == "") Function.Call(ScriptNames.FunctionList.linkto, entity);
            else if (tag != "" && originOffset == null) { Function.Call(ScriptNames.FunctionList.linkto, entity, tag); return; }
            else if (originOffset != null)
            {
                if (originOffset == null) originOffset = Vector3.Zero;
                if (anglesOffset == null) anglesOffset = Vector3.Zero;
                Function.Call(ScriptNames.FunctionList.linkto, entity, tag, originOffset, anglesOffset);
            }
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Transform the given local coordinate point to a world coordinate point
        /// </summary>
        /// <param name="localCoord"></param>
        /// <returns></returns>
        public static void LocalToWorldCoords(this Entity entity, Vector3 localCoord)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.localtoworldcoords, localCoord);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the contents of an entity
        /// </summary>
        /// <param name="contents"></param>
        /// <returns>Returns the old contents of the entity</returns>
        public static int SetContents(this Entity entity, int contents)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcontents, contents);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets a visible cursor near an objective
        /// </summary>
        /// <param name="hint"></param>
        /// <returns></returns>
        public static void SetCursorHint(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcursorhint, hint);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the hint string for a usable entity
        /// </summary>
        /// <param name="hint"></param>
        /// <returns></returns>
        public static void SetHintString(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sethintstring, hint);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the model of the entity to the given model name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void SetModel(this Entity entity, string model)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmodel, model);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the normal health of this entity
        /// </summary>
        /// <param name="health"></param>
        /// <returns></returns>
        public static void SetNormalHealth(this Entity entity, int health)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setnormalhealth, health);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Shows a hidden entity
        /// </summary>
        /// <returns></returns>
        public static void Show(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.show);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Show all parts of an entity
        /// </summary>
        /// <returns></returns>
        public static void ShowAllParts(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showallparts);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Show part of an entity
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void ShowPart(this Entity entity, string tag, string model = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (model != "") Function.Call(ScriptNames.FunctionList.showpart, tag, model);
            else Function.Call(ScriptNames.FunctionList.showpart, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Show the entity to a given client
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void ShowToPlayer(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showtoplayer, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unlinks a linked entity from another entity
        /// </summary>
        /// <returns></returns>
        public static void Unlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.unlink);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Uses the entity with the passed in entity as the activator
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void UseBy(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.useby, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Modifies the use trigger so that it requires the user to be looking at it
        /// </summary>
        /// <returns></returns>
        public static void UseTriggerRequireLookAt(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.usetriggerrequirelookat);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play an effect so that it is attached to this entity
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="position"></param>
        /// <param name="forward"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public static void PlayFX(this Entity entity, int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (forward != null && up != null) Function.Call(ScriptNames.FunctionList.target_playfx, effect, position, forward, up);
            else if (forward != null && up == null) Function.Call(ScriptNames.FunctionList.target_playfx, effect, position, forward);
            else Function.Call(ScriptNames.FunctionList.target_playfx, effect, position);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Creates a scavenger bag from this entity and drops it
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns a reference to the dropped scavenger bag an an <see cref="Entity"/></returns>
        public static Entity DropScavengerBag(this Entity entity, string item)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.dropscavengerbag, item);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Attaches a model to an entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tag"></param>
        /// <param name="ignoreCollision"></param>
        /// <returns></returns>
        public static void Attach(this Entity entity, string model, string tag = "", bool ignoreCollision = false)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attach, model, tag, ignoreCollision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Detaches a model to an entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void Detach(this Entity entity, string model, string tag = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (tag != "") Function.Call(ScriptNames.FunctionList.detach, model, tag);
            else Function.Call(ScriptNames.FunctionList.detach, model);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Detaches all attached model from an entity
        /// </summary>
        /// <returns></returns>
        public static void DetachAll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.detachall);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches the riot shield model to the given tag
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void AttachShieldModel(this Entity entity, string model, string tag)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attachshieldmodel, model, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Detaches the riot shield model from the given tag
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void DetachShieldModel(this Entity entity, string model, string tag)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.detachshieldmodel, model, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Moves the attached riot shield model from the first tag to the second tag
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tag1"></param>
        /// <param name="tag2"></param>
        /// <returns></returns>
        public static void MoveShieldModel(this Entity entity, string model, string tag1, string tag2)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveshieldmodel, model, tag1, tag2);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the number of attached models for this entity
        /// </summary>
        /// <returns>Returns the number of attached models on the given entity</returns>
        public static int GetAttachSize(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachsize);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the name of the attached model at the given attachment slot
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetAttachModelName(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachmodelname, index);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        // <summary>
        /// Gets the tagname of the attached model at the given attachment slot
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetAttachTagName(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachtagname, index);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        // <summary>
        /// Gets the ignore collision flag of the attached model at the given attachment slot
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool GetAttachIgnoreCollision(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachignorecollision, index);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void HidePart_AllInstances(this Entity entity, string tag, string model = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (model != "") Function.Call(ScriptNames.FunctionList.hidepart_allinstances, tag, model);
            else Function.Call(ScriptNames.FunctionList.hidepart_allinstances, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Hides all extra parts of this entity
        /// </summary>
        /// <returns></returns>
        public static void HideAllParts(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hideallparts);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches one entity to another at the tag by blending (TBD)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="originOffset"></param>
        /// <param name="anglesOffset"></param>
        /// <returns></returns>
        public static void LinkToBlendToTag(this Entity ent, Entity entity, string tag)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.linktoblendtotag, entity, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Attaches one entity to another at the tag by blending (TBD)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="originOffset"></param>
        /// <param name="anglesOffset"></param>
        /// <returns></returns>
        public static void LinkToBlendToTag(this Entity ent, Entity entity, string tag, bool collide)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.linktoblendtotag, entity, tag, collide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if this entity is currently linked to another entity
        /// </summary>
        /// <returns>Returns true if this entity is linked to another entity</returns>
        public static bool IsLinked(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.islinked);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Enables LinkTo() for an entity
        /// </summary>
        /// <returns></returns>
        public static void EnableLinkTo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enablelinkto);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on the laser for the alt view(TBD)
        /// </summary>
        /// <returns></returns>
        public static void LaserAltViewOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseraltviewon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns off the laser for the alt view(TBD)
        /// </summary>
        /// <returns></returns>
        public static void LaserAltViewOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseraltviewoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this entity usable to players
        /// </summary>
        /// <returns></returns>
        public static void MakeUsable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeusable);
            //Utils.FuncCaller.ScriptStack.Clear();

        }

        /// <summary>
        /// Makes this entity unusable to players
        /// </summary>
        /// <returns></returns>
        public static void MakeUnUsable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeunusable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the velocity of this entity
        /// </summary>
        /// <returns>Returns the current velocity of this entity</returns>
        public static Vector3 GetEntityVelocity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentityvelocity);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the target entity of a turret or missile
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void SetTargetEnt(this Entity entity, Entity target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetent, target);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the target position of a turret or missile
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void SetTargetPos(this Entity entity, Vector3 target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetpos, target);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clears the current target of this turret or missile
        /// </summary>
        /// <returns></returns>
        public static void ClearTarget(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartarget);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a missile to fly directly toward it's target
        /// </summary>
        /// <returns></returns>
        public static void SetFlightModeDirect(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setflightmodedirect);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a missile to fly up in an arc and then come back down to hit it's target on top
        /// </summary>
        /// <returns></returns>
        public static void SetFlightModeTop(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setflightmodetop);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the intensity of a light entity
        /// </summary>
        /// <returns>Returns the intensity of this light entity</returns>
        public static float GetLightIntensity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getlightintensity);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the intensity of a light entity
        /// </summary>
        /// <param name="intensity"></param>
        /// <returns></returns>
        public static void SetLightIntensity(this Entity entity, float intensity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setlightintensity, intensity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches the player's camera to an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="originOffset"></param>
        /// <param name="anglesOffset"></param>
        /// <returns></returns>
        public static void CameraLinkTo(this Entity ent, Entity entity, string tag = "")
        {
            Function.SetEntRef(ent.EntRef);
            if (tag != "") Function.Call(ScriptNames.FunctionList.cameralinkto, entity, tag);
            else Function.Call(ScriptNames.FunctionList.cameralinkto, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Attaches the player's camera to an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="originOffset"></param>
        /// <param name="anglesOffset"></param>
        /// <returns></returns>
        public static void CameraLinkTo(this Entity ent, Entity entity, string tag, Vector3 originOffset, Vector3 anglesOffset)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.cameralinkto, entity, tag, originOffset, anglesOffset);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unlink the player's camera from an entity
        /// </summary>
        /// <returns></returns>
        public static void CameraUnlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cameraunlink);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Links this player's controls to an entity so that any player input is directed to the linked entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void ControlsLinkTo(this Entity ent, Entity entity)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.controlslinkto, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unlink the player's controls from an entity
        /// </summary>
        /// <returns></returns>
        public static void ControlsUnlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.controlsunlink);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes a vehicle solid with capsule size
        /// </summary>
        /// <param name="xRadius"></param>
        /// <param name="zOffset"></param>
        /// <param name="zRadius"></param>
        /// <returns></returns>
        public static void MakeVehicleSolidCapsule(this Entity entity, float xRadius, float zOffset, float zRadius)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makevehiclesolidcapsule, xRadius, zOffset, zRadius);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes a vehicle solid with sphere size
        /// </summary>
        /// <param name="xRadius"></param>
        /// <param name="zOffset"></param>
        /// <returns></returns>
        public static void MakeVehicleSolidSphere(this Entity entity, float radius, float zOffset)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makevehiclesolidsphere, radius, zOffset);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Transfers any marks on this model to a new script_model(TBD)
        /// </summary>
        /// <returns></returns>
        public static void TransferMarksToNewScriptModel(this Entity entity, Entity ent)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.transfermarkstonewscriptmodel, ent);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clones the given brush model into this script model so it can be controlled by the script
        /// </summary>
        /// <param name="brushModel"></param>
        /// <returns></returns>
        public static void CloneBrushModelToScriptModel(this Entity entity, Entity brushModel)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clonebrushmodeltoscriptmodel, brushModel);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this entity to be usable by the given player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void EnablePlayerUse(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableplayeruse, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this entity to be unusable by the given player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void DisablePlayerUse(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableplayeruse, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this entity into a scrambler so it will behave as a scrambler for the given player
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static void MakeScrambler(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makescrambler, owner);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this entity into a portable radar so it will behave as a partable radar for the given player
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static void MakePortableRadar(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeportableradar, owner);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this entity into a trophy so it will behave as a trophy system for the given player
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static void MakeTrophySystem(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketrophysystem, owner);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if this entity is a spawner or not
        /// </summary>
        /// <returns>Returns true if this entity is a spawner</returns>
        public static bool IsSpawner(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isspawner, entity);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Deletes a missile attractor or repulsor(TBD)
        /// </summary>
        /// <param name="attractor"></param>
        /// <returns></returns>
        public static void DeleteAttractor(Entity attractor)
        {
            //Function.SetEntRef(attractor.EntRef);
            Function.Call(ScriptNames.FunctionList.deleteattractor, attractor);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the default thermal body for players
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static void SetThermalBodyMaterial(string body)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setthermalbodymaterial, body);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the owner of a missile or explosive
        /// </summary>
        /// <param name="explosive"></param>
        /// <returns>Returns the owner of the explosive</returns>
        public static Entity GetMissileOwner(Entity explosive)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmissileowner, explosive);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Looks up an glass piece by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the glass piece found with the given key and name if any</returns>
        public static Entity GetGlass(string name)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getglass, name);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets an array of glass pieces that have the given name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the glass pieces found with the given key and name in a <see cref="Array">Array</see>"/></returns>
        public static Entity GetGlassArray(string name)
        {
            Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getglassarray, name);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;

        }

        /// <summary>
        /// Gets the origin of a piece of glass(TBD)
        /// </summary>
        /// <param name="glass"></param>
        /// <returns>Returns the origin of the glass piece</returns>
        public static Vector3 GetGlassOrigin(int glass)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getglassorigin, glass);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the given glass entity is destroyed or not
        /// </summary>
        /// <param name="glass"></param>
        /// <returns>Returns true if the glass entity is destroyed</returns>
        public static bool IsGlassDestroyed(int glass)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isglassdestroyed, glass);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Shatters a glass entity
        /// </summary>
        /// <param name="glass"></param>
        /// <returns></returns>
        public static void DestroyGlass(int glass)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.destroyglass, glass);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Deletes a glass entity
        /// </summary>
        /// <param name="glass"></param>
        /// <returns></returns>
        public static void DeleteGlass(int glass)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.deleteglass, glass);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the channel count of an entity(TBD)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int GetEntChannelsCount(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentchannelscount, entity);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the channel name of an entity(TBD)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string GetEntChannelName(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentchannelname, entity);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetScriptMoverInKillcam(this Entity mover, string type)
        {
            Function.SetEntRef(mover.EntRef);
            Function.Call(ScriptNames.FunctionList.setscriptmoverinkillcam, type);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a helicopter's current damage state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static void SetDamageState(this Entity entity, int state)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.helicopter_setdamagestate, state);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region file
        /// <summary>
        /// Close a script-controlled file.
        /// </summary>
        /// <param name="fileNum"></param>
        /// <returns>Returns 1 if successful and -1 if unsuccessful</returns>
        public static int CloseFile(int fileNum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closefile, fileNum);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get a specific argument number from the current line.
        /// </summary>
        /// <param name="fileNum"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static void FGetArg(int fileNum, int arg)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fgetarg, fileNum, arg);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Writes items out to a script-controlled file, inserting a comma in-between each one.
        /// </summary>
        /// <param name="fileNum"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static void FPrintFields(int fileNum, params Parameter[] output)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            //Function.Call(ScriptNames.FunctionList.fprintfields, output);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write text out to a script-controlled file.
        /// </summary>
        /// <param name="fileNum"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static void FPrintLn(int fileNum, string output)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fprintln, fileNum, output);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Read the next line of comma separated value text from a script-controlled file.
        /// </summary>
        /// <param name="fileNum"></param>
        /// <returns>Returns the number of comma separated values in the line</returns>
        public static int FReadLn(int fileNum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.freadln, fileNum);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Open a file for reading, writing, or appending.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="mode"></param>
        /// <returns>Returns a file number if successful, otherwise returns -1</returns>
        public static int OpenFile(string filename, string mode)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openfile, filename, mode);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion

        #region hud
        /// <summary>
        /// Set a hud element to transition in fontScale over time. Normally setting the fontScale of an element causes an immediate visual change.
        /// However, if the fontScale gets set within <time> after calling ChangeFontScaleOverTime, then the hud element will transition to the new fontScale over the remaining <time>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void ChangeFontScaleOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.changefontscaleovertime, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clear the config strings for the unique text set after this string. This is intended for development use only.
        /// </summary>
        /// <returns></returns>
        public static void ClearAllTextAfterHudelem(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clearalltextafterhudelem);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clear this waypoint from targetting an entity.
        /// </summary>
        /// <returns></returns>
        public static void ClearTargetEnt(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetent);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Remove this Hud element altogether
        /// </summary>
        /// <returns></returns>
        public static void Destroy(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.destroy);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a hud element to transition in color (or alpha) over time. Normally setting the color (or alpha) of an element causes an immediate visual change. However, if the color (or alpha) gets set within <time> after calling fadeOverTime, then the hud element will transition to the new color over the remaining <time>.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void FadeOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeovertime, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Test fade
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void FadeOverTime2(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeovertime2);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a hud element to move over time.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void MoveOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveovertime, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Test move
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void MoveOverTime2(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveovertime2);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Create a new hud element for a particular client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Returns a reference to the created hud element as a <see cref="HudElem">HudElem</see>"/></returns>
        public static HudElem NewClientHudElem(Entity client)
        {
            //Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.newclienthudelem, client);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            HudElem ret2 = new HudElem(ret);
            return ret2;
        }

        /// <summary>
        /// Create a new hud element
        /// </summary>
        /// <returns>Returns a reference to the created hud element as a <see cref="HudElem">HudElem</see></returns>
        public static HudElem NewHudElem()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.newhudelem);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            HudElem ret2 = new HudElem(ret);
            return ret2;
        }

        /// <summary>
        /// Create a new hud element for a particular team
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns a reference to the created hud element as a <see cref="HudElem">HudElem</see>"/></returns>
        public static HudElem NewTeamHudElem(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.newteamhudelem, team);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            HudElem ret2 = new HudElem(ret);
            return ret2;
        }

        /// <summary>
        /// Create an obituary for a character
        /// </summary>
        /// <param name="victim"></param>
        /// <param name="attacker"></param>
        /// <param name="weapon"></param>
        /// <param name="meansOfDeath"></param>
        /// <returns></returns>
        public static void Obituary(Entity victim, Entity attacker, string weapon, string meansOfDeath)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.obituary, victim, attacker, weapon, meansOfDeath);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Reset a HUD element to its default state.
        /// </summary>
        /// <returns></returns>
        public static void Reset(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.reset);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a hud element to scale over time.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static void ScaleOverTime(this HudElem hud, float time, int width, int height)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scaleovertime, time, width, height);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a clock HUD element to count down over a time period.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="totalTime"></param>
        /// <param name="material"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static void SetClock(this HudElem hud, float time, float totalTime, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclock, totalTime, material, width, height);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a clock HUD element to count up over a time period.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="totalTime"></param>
        /// <param name="material"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static void SetClockUp(this HudElem hud, float time, float totalTime, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclockup, time, totalTime, material, width, height);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the map name string
        /// </summary>
        /// <param name="mapname"></param>
        /// <returns></returns>
        public static void SetMapNameString(this HudElem hud, string mapname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the player name string for a HUD element
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void SetPlayerNameString(this HudElem hud, Entity player)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayernamestring, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the hudelem string to display with a "Pulse" effect.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="decayStart"></param>
        /// <param name="decayDuration"></param>
        /// <returns></returns>
        public static void SetPulseFX(this HudElem hud, int speed, int decayStart, int decayDuration)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setpulsefx, speed, decayStart, decayDuration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }


        /// <summary>
        /// Set the material for this Hud Element.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static void SetShader(this HudElem hud, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setshader, material, width, height);
            hud._shader = material;
            hud.Width = width;
            hud.Height = height;
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the entity that this waypoint should target. In MP, entity should already be a broadcasting entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void SetTargetEnt(this HudElem hud, Entity entity)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetent_hud, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to count down in tenths of a second.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTenthsTimer(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimer, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to count up in tenths of a second.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTenthsTimerUp(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimerup, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set HUD text for this element
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void SetText(this HudElem hud, string text)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settext, text);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to count down.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTimer(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimer, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to count up.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTimerUp(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimerup, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the value HUD element to a given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetValue(this HudElem hud, int value)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvalue, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a HUD element to be a waypoint.
        /// </summary>
        /// <param name="constantSize"></param>
        /// <param name="offscreenMaterial"></param>
        /// <returns></returns>
        public static void SetWaypoint(this HudElem hud, bool constantSize)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Sets a HUD element to be a waypoint.
        /// </summary>
        /// <param name="constantSize"></param>
        /// <param name="offscreenMaterial"></param>
        /// <returns></returns>
        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Sets a HUD element to be a waypoint.
        /// </summary>
        /// <param name="constantSize"></param>
        /// <param name="offscreenMaterial"></param>
        /// <returns></returns>
        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge, bool fadeOutPinnedIcon)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge, fadeOutPinnedIcon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Sets a HUD element to be a waypoint.
        /// </summary>
        /// <param name="constantSize"></param>
        /// <param name="offscreenMaterial"></param>
        /// <returns></returns>
        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge, bool fadeOutPinnedIcon, bool is3D)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge, fadeOutPinnedIcon, is3D);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Shows a splash notification to this player
        /// </summary>
        /// <param name="splash"></param>
        /// <param name="slot"></param>
        /// <param name="optionalNum"></param>
        /// <returns></returns>
        public static void ShowHudSplash(this Entity entity, string splash, int slot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showhudsplash, splash, slot);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Shows a splash notification to this player
        /// </summary>
        /// <param name="splash"></param>
        /// <param name="slot"></param>
        /// <param name="optionalNum"></param>
        /// <returns></returns>
        public static void ShowHudSplash(this Entity entity, string splash, int slot, int optionalNum)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showhudsplash, splash, slot, optionalNum);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to a time and freezes it
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTimerStatic(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimerstatic, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the timer HUD element to a time in tenths of a second and freezes it
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetTenthsTimerStatic(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimerstatic, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a waypoint hud to rotate along the screen while it's offscreen(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SetWaypointEdgeStyle_RotatingIcon(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointedgestyle_rotatingicon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a waypoint hud to have an arrow while offscreen(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SetWaypointEdgeStyle_SecondaryArrow(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointedgestyle_secondaryarrow);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a waypoint hud to only display if it is offscreen(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SetWaypointIconOffScreenOnly(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointiconoffscreenonly);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region level
        /// <summary>
        /// Create an earthquake at the given point.
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="duration"></param>
        /// <param name="source"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static void Earthquake(float scale, float duration, Vector3 source, int radius)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.earthquake, scale, duration, source, radius);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Exits the current level.
        /// </summary>
        /// <param name="savePersistent"></param>
        /// <returns></returns>
        public static void ExitLevel(bool savePersistent)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.exitlevel, savePersistent);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the yaw value of North
        /// </summary>
        /// <returns>Returns the yaw value of North</returns>
        public static float GetNorthYaw()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnorthyaw);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the start time for the current round
        /// </summary>
        /// <returns>Returns the start time for the current round</returns>
        public static int GetStartTime()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getstarttime);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the level time in milliseconds from the start of the level
        /// </summary>
        /// <returns>Returns the level time in milliseconds from the start of the level</returns>
        public static int GetTime()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.gettime);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the game is a splitscreen game
        /// </summary>
        /// <returns>Returns true if the game is a splitscreen game</returns>
        public static bool IsSplitScreen()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issplitscreen);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the string is a valid gametype
        /// </summary>
        /// <param name="gametype"></param>
        /// <returns>Returns true if the string is a valid gametype</returns>
        public static bool IsValidGametype(string gametype)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isvalidgametype, gametype);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the map with the given name exists on the server
        /// </summary>
        /// <param name="mapname"></param>
        /// <returns>Returns true if the map with the given name exists on the server</returns>
        public static bool MapExists(string mapname)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.mapexists, mapname);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Alters the way that the player name is updated, to prevent cheating by spectators altering their name to communicate with active players
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static void SetClientNameMode(string mode)
        {
            //if (mode != "auto_change" || mode != "manual_change")
                //throw new ArgumentException("SetClientNameMode() called with an invalid mode name! Must be 'auto_change' or 'manual_change'.");
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientnamemode, mode);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the time the current match will end
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetGameEndTime(int time)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setgameendtime, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the center of the map (used by network code to optimize position data)
        /// </summary>
        /// <returns></returns>
        public static void SetMapCenter(Vector3 center)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmapcenter, center);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the info for the satelite map on the compass
        /// </summary>
        /// <param name="material"></param>
        /// <param name="upperLeftX"></param>
        /// <param name="upperLeftY"></param>
        /// <param name="lowerRightX"></param>
        /// <param name="lowerRightY"></param>
        /// <returns></returns>
        public static void SetMiniMap(string material, float upperLeftX, float upperLeftY, float lowerRightX, float lowerRightY)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setminimap, material, upperLeftX, upperLeftY, lowerRightX, lowerRightY);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the player to be the winner
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static void SetWinningPlayer(Entity player)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwinningplayer, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a team to be the winner
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void SetWinningTeam(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwinningteam, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Update all client names. Only works in 'manual_change' mode
        /// </summary>
        /// <returns></returns>
        public static void UpdateClientNames()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.updateclientnames);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the Entity number for the world
        /// </summary>
        /// <returns>Returns the entity number for the world</returns>
        public static int WorldEntNumber()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.worldentnumber);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the level's sunlight color
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static void SetSunlight(Vector3 rgb)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setsunlight, rgb.X, rgb.Y, rgb.Z);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Resets the level's sunlight color to default
        /// </summary>
        /// <returns></returns>
        public static void ResetSunlight()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.resetsunlight);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Restarts the current game
        /// </summary>
        /// <returns></returns>
        public static void Map_Restart(bool savePersistant)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.map_restart, savePersistant);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Ends the current match(TBD)
        /// </summary>
        /// <returns></returns>
        public static void MatchEnd()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.matchend);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Ends the current party
        /// </summary>
        /// <returns></returns>
        public static void EndParty()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.endparty);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the minimum uav strength
        /// </summary>
        /// <returns>Returns the minimum value of uav strength</returns>
        public static int GetUAVStrengthMin()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getuavstrengthmin);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the maximum uav strength
        /// </summary>
        /// <returns>Returns the maximum value of uav strength</returns>
        public static int GetUAVStrengthMax()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getuavstrengthmax);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the neutral uav strength value
        /// </summary>
        /// <returns>Returns the neutral value of uav strength</returns>
        public static int GetUAVStrengthLevelNeutral()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelneutral);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the uav strength level at which the radar will sweep for enemies in a fast speed
        /// </summary>
        /// <returns>Returns the value of uav strength that will sweep the radar fast</returns>
        public static int GetUAVStrengthLevelShowEnemyFastSweep()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelshowenemyfastsweep);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the uav strength level at which the radar will show enemy direction
        /// </summary>
        /// <returns>Returns the value of uav strength that will show enemy direction</returns>
        public static int GetUAVStrengthLevelShowEnemyDirectional()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelshowenemydirectional);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets a value for the current match's data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMatchData(params Parameter[] data)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmatchdata, data);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a value of a field of the current match's data
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns the value of the given field in the current match's data</returns>
        public static Parameter GetMatchData(params Parameter[] data)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmatchdata, data);

            Parameter ret = new Parameter(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Send the current match data to all clients(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SendMatchData()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sendmatchdata);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clears all match data fields to default
        /// </summary>
        /// <returns></returns>
        public static void ClearMatchData()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clearmatchdata);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the current match's matchdata definition file(TBD)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SetMatchDataDef(string name)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmatchdatadef, name);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets up a client's ip in the match data(TBD)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static void SetMatchClientIP(Entity client, int clientID)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmatchclientip, client, clientID);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the ID of the current match's matchdata(TBD)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void SetMatchDataID()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmatchdataid);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a field in the client's match 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataID"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetClientMatchData(params Parameter[] data)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientmatchdata, data);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a field in the client's match data
        /// </summary>
        /// <returns></returns>
        public static Parameter GetClientMatchData(params Parameter[] dataNames)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getclientmatchdata, dataNames);

            Parameter ret = new Parameter(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets a client's matchdata definition file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SetClientMatchDataDef(string name)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientmatchdatadef, name);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Send a client's current match data to the server(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SendClientMatchData()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sendclientmatchdata);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a rule value from the current match's rules
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="parameters"></param>
        /// <returns>Returns the value of the given rule</returns>
        public static string GetMatchRulesData(string rule, params string[] parameters)
        {
            //Function.SetEntRef(entity.EntRef);
            Parameter[] pass = new Parameter[parameters.Length + 1];
            pass[0] = rule;
            for (int i = 1; i < pass.Length; i++)
            {
                pass[i] = parameters[i-1];
            }
            Function.Call(ScriptNames.FunctionList.getmatchrulesdata, pass);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the server is using match rules data or not
        /// </summary>
        /// <returns>Returns true if the server is using match rules data</returns>
        public static bool IsUsingMatchRulesData()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isusingmatchrulesdata);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Ends the current lobby
        /// </summary>
        /// <returns></returns>
        public static void EndLobby()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.endlobby);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets info from the basemaps.arena file
        /// </summary>
        /// <param name="name">The name of the variable in the arena file to get the value from</param>
        /// <returns>Returns the value of the given variable located in the basemaps.arena file</returns>
        public static string GetMapCustom(string name)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmapcustom, name);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Updates the skill value for two players(TBD)
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <param name="gametype"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static void UpdateSkill(Entity attacker, Entity defender, string gametype, float scalar)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.updateskill, attacker, defender, gametype, scalar);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the north yaw value
        /// </summary>
        /// <param name="yaw"></param>
        /// <returns></returns>
        public static void SetNorthYaw(int yaw)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setnorthyaw, yaw);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets slow motion for the game, smoothing from startScale to endScale for lerpDuration time
        /// </summary>
        /// <param name="startScale"></param>
        /// <param name="endScale"></param>
        /// <param name="lerpDuration"></param>
        /// <returns></returns>
        public static void SetSlowMotion(float startScale, float endScale, float lerpDuration)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setslowmotion, startScale, endScale, lerpDuration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this world's exponential fog values
        /// </summary>
        /// <param name="startDist"></param>
        /// <param name="halfwayDist"></param>
        /// <param name="rgb"></param>
        /// <param name="opacity"></param>
        /// <param name="transitionTime"></param>
        /// <param name="sunRGB"></param>
        /// <param name="sunOpacity"></param>
        /// <param name="sunDirection"></param>
        /// <param name="sunBeginFadeAngle"></param>
        /// <param name="sunEndFadeAngle"></param>
        /// <returns></returns>
        public static void SetExpFog(float startDist, float halfwayDist, Vector3 rgb, float opacity, float transitionTime, Vector3 sunRGB, float sunOpacity, Vector3 sunDirection, float sunBeginFadeAngle, float sunEndFadeAngle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setexpfog, startDist, halfwayDist, rgb.X, rgb.Y, rgb.Z, opacity, transitionTime, sunRGB.X, sunRGB.Y, sunRGB.Z, sunOpacity, sunDirection, sunBeginFadeAngle, sunEndFadeAngle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Looks up a vehicle node with the given key, name pair
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the vehicle node found with the given key and name if any</returns>
        public static Entity GetVehicleNode(string name, string key)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getvehiclenode, name, key);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets an array of vehicle nodes that have the given key, name pair
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns>Returns the vehicle nodes found with the given key and name in a <see cref="Array">Array</see>"/></returns>
        public static Entity GetVehicleNodeArray(string name, string key)
        {
            //throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);

            Function.Call(ScriptNames.FunctionList.getvehiclenodearray, name, key);

            //Array ret;
            Entity value = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return value;

        }

        /// <summary>
        /// Gets all of the vehicle nodes in the current level
        /// </summary>
        /// <returns>Returns all of the vehicle nodes found in the level in a <see cref="Array">Array</see>"/></returns>
        public static Entity GetAllVehicleNodes()
        {
            //throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);

            Function.Call(ScriptNames.FunctionList.getallvehiclenodes);

            //Array ret;
            Entity value = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return value;

        }

        /// <summary>
        /// Gets the current vehicle count of the level
        /// </summary>
        /// <returns>Returns the vehicle count of the level</returns>
        public static int GetNumVehicles()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnumvehicles);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets all of the current vehicle spawners within the level
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns all of the current vehicle spawners in the level in a <see cref="Array"/></returns>
        public static Entity Vehicle_GetSpawnerArray()
        {
            //throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);

            Function.Call(ScriptNames.FunctionList.vehicle_getspawnerarray);

            //Array ret;
            Entity value = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return value;

        }

        /// <summary>
        /// Gets all of the current vehicles within the level
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns all of the current vehicles in the level in a <see cref="Array"/></returns>
        public static Entity Vehicle_GetArray()
        {
            //throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_getarray);

            //Array ret;
            Entity value = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return value;
        }

        /// <summary>
        /// Gets the current total count of the given world stat
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public static int GetCounterTotal(string stat)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcountertotal, stat);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Increments the given world stat by the given number
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public static void IncrementCounter(string stat, int increment)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.incrementcounter, stat, increment);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region math
        /// <summary>
        /// Calculates an angle corresponding to a particular cosine value
        /// </summary>
        /// <param name="cosValue"></param>
        /// <returns>Returns an angle corresponding to a particular cosine value</returns>
        public static float ACos(float cosValue)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.acos, cosValue);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates an angle corresponding to a particular sin value
        /// </summary>
        /// <param name="sinValue"></param>
        /// <returns>Returns an angle corresponding to a particular sin value</returns>
        public static float ASin(float sinValue)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.asin, sinValue);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates an angle corresponding to a particular tangential value
        /// </summary>
        /// <param name="tanValue"></param>
        /// <returns>Returns an angle corresponding to a particular tangential value</returns>
        public static float ATan(float tanValue)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.atan, tanValue);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the cos of an angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Returns the cos of an angle</returns>
        public static float Cos(float angle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cos, angle);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Cast a floating point number or a string to an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns the newly casted float/string as an int</returns>
        public static int Int(float value)
        {
            int ret = (int)value;
            return ret;
        }
        /// <summary>
        /// Cast a string to a floating point number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns the newly casted string as a float</returns>
        public static float Float(string value)
        {
            float ret = float.Parse(value);
            return ret;
        }

        /// <summary>
        /// Calculates the point closest to a given point on a given line segment.
        /// </summary>
        /// <param name="segmentA"></param>
        /// <param name="segmentB"></param>
        /// <param name="point"></param>
        /// <returns>Returns the point nearest the given point on the given line segment</returns>
        public static Vector3 PointOnSegmentNearestToPoint(Vector3 segmentA, Vector3 segmentB, Vector3 point)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.pointonsegmentnearesttopoint, segmentA, segmentB, point);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Randomize a floating point number that is above 0 and below the max number specified.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>Returns the randomized float more than 0 and less than the given max</returns>
        public static float RandomFloat(float max)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.randomfloat, max);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Randomize a floating point number that is between the two ranges specified.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Returns the randomized float between the given ranges</returns>
        public static float RandomFloatRange(float min, float max)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.randomfloatrange, min, max);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Randomize an int that is above 0 and max-1 inclusive.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>Returns the randomized int more than 0 and less than the given max</returns>
        public static int RandomInt(int max)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.randomint, max);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Randomize an int that is between the given ranges.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Returns the randomized int between the two given ranges</returns>
        public static int RandomIntRange(int min, int max)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.randomintrange, min, max);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the sin of an angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Returns the sin of an angle</returns>
        public static float Sin(float angle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sin, angle);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the tan of an angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Returns the tan of an angle</returns>
        public static float Tan(float angle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tan, angle);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates a vector perpendicular to the given line and pointing from the line to the given point.
        /// </summary>
        /// <param name="segmentA"></param>
        /// <param name="segmentB"></param>
        /// <param name="point"></param>
        /// <returns>Returns a vector perpendicular to the given line and pointing from the line to the given point</returns>
        public static Vector3 VectorFromLineToPoint(Vector3 segmentA, Vector3 segmentB, Vector3 point)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectorfromlinetopoint, segmentA, segmentB, point);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the absolute value of the given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the absolute value of the given number</returns>
        public static float Abs(float input)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.abs, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Returns the given number, where the given minimum is lowest possible return value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="minimum"></param>
        /// <returns>Returns the given number that is above the minimum</returns>
        public static float Min(float input, float minimum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.min, input, minimum);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Returns the given number, where the given maximum is highest possible return value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="maximum"></param>
        /// <returns>Returns the given number that is below the maximum</returns>
        public static float Max(float input, float maximum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.max, input, maximum);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the lowest possible value of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the lowest possible value of the given number</returns>
        public static float Floor(float input)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.floor, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the highest possible value of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the highest possible value of the given number</returns>
        public static float Ceil(float input)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ceil, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the exponent of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the exponent of the given number</returns>
        public static float Exp(float input)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.exp, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the log of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the log of the given number</returns>
        public static float Log(float input)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.log, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the square root of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the square root of the given number</returns>
        public static float Sqrt(float input)
        {
            /*
            //Function.SetEntRef(entity.EntRef);
Function.Call(ScriptNames.FunctionList.sqrt, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
             */
            float ret = (float)Math.Sqrt(input);
            return ret;
        }

        /// <summary>
        /// Calculates the squared value of the given number(TBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the square of the given number</returns>
        public static float Squared(float input)
        {
            /*
            //Function.SetEntRef(entity.EntRef);
Function.Call(ScriptNames.FunctionList.squared, input);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
             */
            float ret = input *= input;
            return ret;
        }

        /// <summary>
        /// Clamps a given value inbetween the min and max
        /// </summary>
        /// <param name="input"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns>Returns the given number within the maximum and minimum values</returns>
        public static float Clamp(float input, float minimum, float maximum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clamp, input, minimum, maximum);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Clamps a given angle inbetween the min and max
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns>Returns the given angle within the maximum and minimum values</returns>
        public static Vector3 AngleClamp(Vector3 angle, float minimum, float maximum)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.angleclamp, angle, minimum, maximum);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Clamps a given angle so that it is within 0 and 180 degrees(TBD)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Returns the given angle within 0 and 180 degrees</returns>
        public static Vector3 AngleClamp180(float angle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.angleclamp180, angle);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion

        #region menu
        /// <summary>
        /// Opens a pop up menu over the current menu/screen
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void OpenPopUpMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openpopupmenu, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Opens a pop up menu over the current menu/screen, with no mouse control
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void OpenPopUpMenuNoMouse(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openpopupmenunomouse, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Closes the specified pop up menu if it is currently open
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void ClosePopUpMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closepopupmenu, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Opens a menu over the current menu/screen
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void OpenMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openmenu, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Closes the current player menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void CloseMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closemenu, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Closes the in-game menu for this client
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void CloseInGameMenu(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closeingamemenu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region motion
        /// <summary>
        /// Fling this entity
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void MoveGravity(this Entity entity, Vector3 velocity, int time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movegravity, velocity, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Move this entity to the given point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveTo(this Entity entity, Vector3 point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Move this entity to the given point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveTo(this Entity entity, Vector3 point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /// <summary>
        /// Move this entity to the given point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveTo(this Entity entity, Vector3 point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Move this entity to the given world x value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveX(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveX(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveX(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Move this entity to the given world y value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveY(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveY(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveY(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Move this entity to the given world z value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void MoveZ(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveZ(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void MoveZ(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unsets the solid flag, so that this object is no longer collidable
        /// </summary>
        /// <returns></returns>
        public static void NotSolid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.notsolid);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Permanently turn this entity into a client physics object with an initial force vector at the specified point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsLaunchClient(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchclient, point, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Permanently turn this entity into a server physics object with an initial force vector at the specified point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsLaunchServer(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchserver, point, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Rotate this entity to the given pitch
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void RotatePitch(this Entity entity, int pitch, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotatePitch(this Entity entity, int pitch, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotatePitch(this Entity entity, int pitch, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Rotate this entity to the given roll angle
        /// </summary>
        /// <param name="roll"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void RotateRoll(this Entity entity, int roll, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateRoll(this Entity entity, int roll, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateRoll(this Entity entity, int roll, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Rotate this entity to the given world rotation value
        /// </summary>
        /// <param name="angles"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void RotateTo(this Entity entity, Vector3 angles, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateTo(this Entity entity, Vector3 angles, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateTo(this Entity entity, Vector3 angles, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Rotate this entity at a particular velocity for a given time
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Rotate this entity to the given yaw
        /// </summary>
        /// <param name="yaw"></param>
        /// <param name="time"></param>
        /// <param name="accelTime"></param>
        /// <param name="decelTime"></param>
        /// <returns></returns>
        public static void RotateYaw(this Entity entity, int yaw, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateYaw(this Entity entity, int yaw, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, accelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void RotateYaw(this Entity entity, int yaw, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, accelTime, decelTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the solid flag, so that this object is collidable
        /// </summary>
        /// <returns></returns>
        public static void Solid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.solid);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Causes a script entity to vibrate, rotating around its origin, along a given vector direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="amplitude"></param>
        /// <param name="period"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void Vibrate(this Entity entity, Vector3 direction, float amplitude, float period, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vibrate, direction, amplitude, period, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Moves this entity by sliding it(TBD)
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public static void MoveSlide(this Entity entity, Vector3 point, float time, Vector3 velocity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveslide, point, time, velocity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stops this entity from sliding
        /// </summary>
        /// <returns></returns>
        public static void StopMoveSlide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopmoveslide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Add pitch in local space. Does not interpolate
        /// </summary>
        /// <param name="pitch"></param>
        /// <returns></returns>
        public static void AddPitch(this Entity entity, int pitch)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addpitch, pitch);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Add yaw in local space. Does not interpolate
        /// </summary>
        /// <param name="yaw"></param>
        /// <returns></returns>
        public static void AddYaw(this Entity entity, int yaw)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addyaw, yaw);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Add roll in local space. Does not interpolate
        /// </summary>
        /// <param name="roll"></param>
        /// <returns></returns>
        public static void AddRoll(this Entity entity, int roll)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addroll, roll);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Launches this item
        /// </summary>
        /// <param name="point"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsLaunchServerItem(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchserveritem, point, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unknown effect
        /// </summary>
        /// <returns></returns>
        public static Entity TransformMove(Vector3 position1, Vector3 angles1, Vector3 position2, Vector3 angles2, Vector3 entityPosition, Vector3 entityAngles)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.transformmove, position1, angles1, position2, angles2, entityPosition, entityAngles);
            //Utils.FuncCaller.ScriptStack.Clear();

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Create a physics explosion in the shape of a sphere that will hit any physics objects withing the given radius
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsExplosionSphere(Vector3 center, int radius, int height, int force)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicsexplosionsphere, center, radius, height, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Create a physics explosion in the shape of a cylinder that will hit any physics objects withing the given radius
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsExplosionCylinder(Vector3 center, int radius, int height, int force)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicsexplosioncylinder, center, radius, height, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Imparts a 1-frame randomly-jittered impulse on physics objects in a radius.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="outerRadius"></param>
        /// <param name="innerRadius"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public static void PhysicsJolt(Vector3 center, int outerRadius, int innerRadius, int force)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicsjolt, center, outerRadius, innerRadius, force);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Jitters physics objects touching the ground. Jitter forces are calculated in such a way as to displace the object upwards some height between min and max displacement at each point of contact with the ground.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="outerRadius"></param>
        /// <param name="innerRadius"></param>
        /// <param name="minDisplacement"></param>
        /// <param name="maxDisplacement"></param>
        /// <returns></returns>
        public static void PhysicsJitter(Vector3 center, int outerRadius, int innerRadius, float minDisplacement, float maxDisplacement)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicsjitter, center, outerRadius, innerRadius, minDisplacement, maxDisplacement);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region objective
        /// <summary>
        /// Adds a new objective
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="state"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="shader"></param>
        /// <returns></returns>
        public static void Objective_Add(int objectiveNumber, string state, Vector3? position = null, string shader = "")
        {
            if (position == null && shader == "") Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state);
            else if (shader == "") Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state, position);
            //Function.SetEntRef(entity.EntRef);
            else Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state, position, shader);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set which objective(s) are currently being done. If none specified, there's no current objective. Current objectives that are not specified to still be current, are set to active.
        /// </summary>
        /// <param name="objectiveIndex"></param>
        /// <param name="additionalIndex"></param>
        /// <returns></returns>
        public static void Objective_Current(int objectiveIndex, params int[] additionalIndex)
        {
            //Function.SetEntRef(entity.EntRef);
            Parameter[] pass = new Parameter[additionalIndex.Length + 1];
            pass[0] = objectiveIndex;
            for (int i = 1; i > pass.Length; i++)
            {
                pass[i] = additionalIndex[i - 1];
            }
            Function.Call(ScriptNames.FunctionList.objective_current, pass);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Removes an objective
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <returns></returns>
        public static void Objective_Delete(int objectiveNumber)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_delete, objectiveNumber);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the compass icon for an objective
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void Objective_Icon(int objectiveNumber, string icon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_icon, objectiveNumber, icon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the objective to get it's position from an entity
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void Objective_OnEntity(int objectiveNumber, Entity entity)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_onentity, objectiveNumber, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the position of an objective, assumed to be the zeroth position
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static void Objective_Position(int objectiveNumber, Vector3 position)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_position, objectiveNumber, position);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the state of an objective
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static void Objective_State(int objectiveNumber, string state)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_state, objectiveNumber, state);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the team that the objective is for. Allows having different objectives for each team
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void Objective_Team(int objectiveNumber, string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_team, objectiveNumber, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Flashes a player on their teammate's compasses
        /// </summary>
        /// <returns></returns>
        public static void PingPlayer(this Entity player)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.pingplayer);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the objective to get it's position from a player
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public static void Objective_Player(int objectiveNumber, int playerNumber)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_player, objectiveNumber, playerNumber);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the objective to get it's position from a player for the player's team(TBD)
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public static void Objective_PlayerTeam(int objectiveNumber, int playerNumber)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_playerteam, objectiveNumber, playerNumber);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the objective to get it's position from a player for the enemy team(TBD)
        /// </summary>
        /// <param name="objectiveNumber"></param>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public static void Objective_PlayerEnemyTeam(int objectiveNumber, int playerNumber)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.objective_playerenemyteam, objectiveNumber, playerNumber);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region player
        /// <summary>
        /// Check if the player is pressing the 'ads' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'ads' button</returns>
        public static bool AdsButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.adsbuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Sets whether the player can switch to ADS
        /// </summary>
        /// <param name="ads"></param>
        /// <returns></returns>
        public static void AllowAds(this Entity entity, bool ads)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowads, ads);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether the player can jump
        /// </summary>
        /// <param name="jump"></param>
        /// <returns></returns>
        public static void AllowJump(this Entity entity, bool jump)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowjump, jump);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether the player can sprint
        /// </summary>
        /// <param name="sprint"></param>
        /// <returns></returns>
        public static void AllowSprint(this Entity entity, bool sprint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowsprint, sprint);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the player has any ammo available for the weapon or any of it's alt-modes (grenade launcher, etc)
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the player has any ammo available for the weapon or any of it's alt-modes</returns>
        public static bool AnyAmmoForWeaponModes(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.anyammoforweaponmodes, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Check if the player is pressing the 'attack' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'attack' button</returns>
        public static bool AttackButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attackbuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Check if the host is pressing the button/key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns true if the host is pressing the button/key</returns>
        public static bool ButtonPressed(this Entity entity, string key)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.buttonpressed, key);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Removes all perks for a player
        /// </summary>
        /// <returns></returns>
        public static void ClearPerks(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clearperks);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Deactivates the channel volumes for the player on the given priority level
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void DeactivateChannelVolumes(this Entity entity, string priority, int fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.deactivatechannelvolumes, priority, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Deactivates the sound reverbation for the player on the given priority level
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void DeactivateReverb(this Entity entity, string priority, int fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.deactivatereverb, priority, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Check if the player is pressing the 'frag' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'frag' button</returns>
        public static bool FragButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fragbuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Blocks or unblocks control input from this player
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static void FreezeControls(this Entity entity, bool state)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.freezecontrols, state);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the player's current off-hand weapon
        /// </summary>
        /// <returns>Returns the name of the player's current offhand weapon</returns>
        public static string GetCurrentOffhand(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentoffhand);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's current weapon
        /// </summary>
        /// <returns>Returns the name of the player's current weapon</returns>
        public static string GetCurrentWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentweapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the amount of ammo left in the player's clip
        /// </summary>
        /// <returns>Returns the amount of ammo in the player's clip</returns>
        public static int GetCurrentWeaponClipAmmo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentweaponclipammo);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's current ammunition amount as a fraction of the weapon's maximum ammunition
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the player's current ammunition as a fraction of the weapon's maximum ammunition represented as a float</returns>
        public static float GetFractionMaxAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getfractionmaxammo, weapon);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's current ammunition amount as a fraction of the weapon's starting ammunition
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the player's current ammunition as a fraction of the weapon's starting ammunition represented as a float</returns>
        public static float GetFractionStartAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getfractionstartammo, weapon);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's normalized movement vector
        /// </summary>
        /// <returns>Returns (-1, 1) for X(forward) and Y(right) based on player's input</returns>
        public static Vector3 GetNormalizedMovement(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalizedmovement);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's camera's normalized movement vector
        /// </summary>
        /// <returns>Returns (-1, 1) for X(forward) and Y(right) based on player's input</returns>
        public static Vector3 GetNormalizedCameraMovement(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalizedcameramovement);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the name that toggle is set to
        /// </summary>
        /// <returns>Returns the name (either 'smoke' or 'flash') of the player's secondary offhand class</returns>
        public static string GetOffhandSecondaryClass(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getoffhandsecondaryclass);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's angles
        /// </summary>
        /// <returns>Returns the player's angles</returns>
        public static Vector3 GetPlayerAngles(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerangles);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the stance of the player. It only works for the player
        /// </summary>
        /// <returns>Returns the stance of the player. Possible return values are 'crouch', 'prone', and 'stand'</returns>
        public static string GetStance(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getstance);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's cvelocity
        /// </summary>
        /// <returns>Returns the player's velocity</returns>
        public static Vector3 GetVelocity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getvelocity);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the amount of ammo left in the player's weapon's current clip
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the amount of ammo left in the player's weapon's current clip</returns>
        public static int GetWeaponAmmoClip(this Entity entity, string weapon, string clipSide = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (clipSide != null) Function.Call(ScriptNames.FunctionList.getweaponammoclip, weapon, clipSide);
            else Function.Call(ScriptNames.FunctionList.getweaponammoclip, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the ammunition stockpile for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the amount of reserve ammo the player has for the given weapon</returns>
        public static int GetWeaponAmmoStock(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponammostock, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets an array of all weapons that the player has. Includes any alt-mode weapons
        /// </summary>
        /// <returns>Returns an array of all the weapons that the player has, including alt-mode meapons</returns>
        public static Entity GetWeaponsList(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslist);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Gets an array of all weapons that the player has. Includes any alt-mode, offhand, and exclusive weapons
        /// </summary>
        /// <returns>Returns an array of all the weapons that the player has</returns>
        public static Entity GetWeaponsListAll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistall);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Gets an array of all primary weapons that the player has
        /// </summary>
        /// <returns>Returns an array of all the primary weapons that the player has</returns>
        public static Entity GetWeaponsListPrimaries(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistprimaries);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Gets an array of all offhand weapons that the player has
        /// </summary>
        /// <returns>Returns an array of all the offhand weapons that the player has</returns>
        public static Entity GetWeaponsListOffhands(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistoffhands);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Gets an array of all item weapons that the player has
        /// </summary>
        /// <returns>Returns an array of all the item weapons that the player has</returns>
        public static Entity GetWeaponsListItems(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistitems);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Gets an array of all exclusive weapons that the player has
        /// </summary>
        /// <returns>Returns an array of all the exclusive weapons that the player has</returns>
        public static Entity GetWeaponsListExclusives(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistexclusives);

            //Array ret;
            Entity result = (Entity)Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            return result;
        }

        /// <summary>
        /// Sets the player's ammunition to the weapon's maximum ammunition
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void GiveMaxAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.givemaxammo, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the player's ammunition to the weapon's default starting ammunition
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void GiveStartAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.givestartammo, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Give the player a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void GiveWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void GiveWeapon(this Entity entity, string weapon, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon, index);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void GiveWeapon(this Entity entity, string weapon, int index, bool akimbo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon, index, akimbo);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Test if a player has a perk
        /// </summary>
        /// <param name="perk"></param>
        /// <returns>Returns true if the player has the perk</returns>
        public static bool HasPerk(this Entity entity, string perk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hasperk, perk);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the player has the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the player has the given weapon</returns>
        public static bool HasWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hasweapon, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the player is on the ground
        /// </summary>
        /// <returns>Returns true if the player is on ground</returns>
        public static bool IsOnGround(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isonground);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Check if the player is pressing the 'melee' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'melee' button</returns>
        public static bool MeleeButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.meleebuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Whenever the console command processor encounters <command> for any reason, it will notify script with the string <notify> on the player entity. Additionally, it will pass the arguments to the notify as strings, where the first argument is the initiating command.
        /// </summary>
        /// <param name="notify"></param>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static void NotifyOnPlayerCommand(this Entity entity, string notify, string command)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.notifyonplayercommand, notify, command);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the player's weapon position fraction
        /// </summary>
        /// <returns>Returns the player's weapon position fraction</returns>
        public static float PlayerAds(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerads);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Attaches the player to an entity. Any entity rotation is added to the player's view, allow the player to look around. Rotating the parent entity/tag will not move the player's eye position, but only the player's view angles. Thus, the player's eye position is locked in place, always directly above the parent tag.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="viewFraction"></param>
        /// <param name="rightArc"></param>
        /// <param name="leftArc"></param>
        /// <param name="topArc"></param>
        /// <param name="bottomArc"></param>
        /// <param name="collide"></param>
        /// <returns></returns>
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "") Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag);
            else Function.Call(ScriptNames.FunctionList.playerlinkto, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches the player to an entity. No view movement is allowed. The player's eye position will remain fixed relative to the parent entity/tag. Thus, pitching and rolling will cause the player's eye position to move. (But the player entity always remains vertical)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void PlayerLinkToAbsolute(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "") Function.Call(ScriptNames.FunctionList.playerlinktoabsolute, entity, tag);
            else Function.Call(ScriptNames.FunctionList.playerlinktoabsolute, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Attaches the player to an entity. Any entity rotation is added to the player's view, allow the player to look around. The player's eye position will remain fixed relative to the parent entity/tag. Thus, pitching and rolling will cause the player's eye position to move. (But the player entity always remains vertical)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="viewFraction"></param>
        /// <param name="rightArc"></param>
        /// <param name="leftArc"></param>
        /// <param name="topArc"></param>
        /// <param name="bottomArc"></param>
        /// <param name="useTagAngles"></param>
        /// <returns></returns>
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "") Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag);
            else Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays a sound locally to the player
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlayLocalSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playlocalsound, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Resets the player spread value to the ones of the weapon in use
        /// </summary>
        /// <returns></returns>
        public static void ResetSpreadOverride(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.resetspreadoverride);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Check if the player is pressing the 'secondary offhand' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'secondary offhand' button</returns>
        public static bool SecondaryOffhandButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.secondaryoffhandbuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Sets the option to perform when the player executes (for example) '+actionslot 1'
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="option"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void SetActionSlot(this Entity entity, int slot, string option, string weapon = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (weapon != "") Function.Call(ScriptNames.FunctionList.setactionslot, slot, option, weapon);
            else Function.Call(ScriptNames.FunctionList.setactionslot, slot, option);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the channel volumes for the player (a way of fading volumes by type)
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="shockName"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void SetChannelVolumes(this Entity entity, string priority, string shockName, float fade = 0f)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setchannelvolumes, priority, shockName, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the values of a dvar which are specific to each client
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetClientDvar(this Entity entity, string dvar, Parameter value)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientdvar, dvar, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the values of a list of dvars which are specific to each client
        /// </summary>
        /// <param name="dvar"></param>
        /// <param name="value"></param>
        /// <param name="additionalDvars"></param>
        /// <param name="additionalValues"></param>
        /// <returns></returns>
        public static void SetClientDvars(this Entity entity, string dvar, Parameter value, params Parameter[] additionalValues)
        {
            Parameter[] pass = new Parameter[additionalValues.Length + 2];
            pass[0] = dvar;
            pass[1] = value;
            for (int i = 2; i < pass.Length; i++)
                pass[i] = additionalValues[i - 2];
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientdvars, pass);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the depth of field values for a player. If start >= end for near or far, depth of field is disabled for that region
        /// </summary>
        /// <param name="nearStart"></param>
        /// <param name="nearEnd"></param>
        /// <param name="farStart"></param>
        /// <param name="farEnd"></param>
        /// <param name="nearBlur"></param>
        /// <param name="farBlur"></param>
        /// <returns></returns>
        public static void SetDepthOfField(this Entity entity, int nearStart, int nearEnd, int farStart, int farEnd, float nearBlur, float farBlur)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdepthoffield, nearStart, nearEnd, farStart, farEnd, nearBlur, farBlur);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Scales player movement speed by this amount
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetMoveSpeedScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmovespeedscale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set whether the player can use smoke grenades or flashbangs
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SetOffhandSecondaryClass(this Entity entity, string name)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setoffhandsecondaryclass, name);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the player's origin
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static void SetOrigin(this Entity entity, Vector3 origin)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setorigin, origin);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Give the specified perk
        /// </summary>
        /// <param name="perk"></param>
        /// <param name="codePerk"></param>
        /// <param name="useSlot"></param>
        /// <returns></returns>
        public static void SetPerk(this Entity entity, string perk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void SetPerk(this Entity entity, string perk, bool codePerk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk, codePerk);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void SetPerk(this Entity entity, string perk, bool codePerk, bool useSlot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk, codePerk, useSlot);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the player's angles
        /// </summary>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static void SetPlayerAngles(this Entity entity, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerangles, angles);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the sound reverbation for the player
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="roomType"></param>
        /// <param name="dryLevel"></param>
        /// <param name="wetLevel"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void SetReverb(this Entity entity, string priority, string roomType, float dryLevel = 0f, float wetLevel = 0f, float fade = 0f)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setreverb, priority, roomType, dryLevel, wetLevel, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the player fixed spread value
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        public static void SetSpreadOverride(this Entity entity, int spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setspreadoverride, spread);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the player's velocity
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public static void SetVelocity(this Entity entity, Vector3 velocity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvelocity, velocity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the player's current viewmodel
        /// </summary>
        /// <param name="viewmodel"></param>
        /// <returns></returns>
        public static void SetViewModel(this Entity entity, string viewmodel)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewmodel, viewmodel);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the depth of field values for the player's viewmodel when at hip. If start >= end, depth of field is disabled
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static void SetViewModelDepthOfField(this Entity entity, float start, float end)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewmodeldepthoffield, start, end);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the weapon clip ammunition for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="ammo"></param>
        /// <returns></returns>
        public static void SetWeaponAmmoClip(this Entity entity, string weapon, int ammo, string clipSide = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (clipSide != null) Function.Call(ScriptNames.FunctionList.setweaponammoclip, weapon, ammo, clipSide);
            else Function.Call(ScriptNames.FunctionList.setweaponammoclip, weapon, ammo);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the ammunition stockpile for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="ammo"></param>
        /// <returns></returns>
        public static void SetWeaponAmmoStock(this Entity entity, string weapon, int ammo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setweaponammostock, weapon, ammo);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Start a shell shock sequence for the player. The shell shock must be precached, otherwise calling this script will cause a script error
        /// </summary>
        /// <param name="shellshock"></param>
        /// <param name="duration"></param>
        /// <param name="overrideCheat"></param>
        /// <returns></returns>
        public static void ShellShock(this Entity entity, string shellshock, float duration)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shellshock, shellshock, duration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void ShellShock(this Entity entity, string shellshock, float duration, bool overrideCheat)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shellshock, shellshock, duration, overrideCheat);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stops all instances of a local soundalias running on a player
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void StopLocalSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoplocalsound, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stop a shell shock sequence for the player
        /// </summary>
        /// <returns></returns>
        public static void StopShellShock(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopshellshock);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Switch to the player's offhand weapon
        /// </summary>
        /// <returns></returns>
        public static void SwitchToOffhand(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtooffhand);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Switch to a different weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void SwitchToWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtoweapon, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Switch to a different weapon immediately, skipping any animations
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void SwitchToWeaponImmediate(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtoweaponimmediate, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Remove all the weapons from the player
        /// </summary>
        /// <returns></returns>
        public static void TakeAllWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.takeallweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Take a weapon from the player
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void TakeWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.takeweapon, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Takes the specified perk from the player
        /// </summary>
        /// <param name="perk"></param>
        /// <returns></returns>
        public static void UnSetPerk(this Entity entity, string perk, bool useSlot = true)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.unsetperk, perk, useSlot);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Check if the player is pressing the 'use' button
        /// </summary>
        /// <returns>Returns true if the player is pressing the 'use' button</returns>
        public static bool UseButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.usebuttonpressed);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Throw the screen around as if the player has been damaged
        /// </summary>
        /// <param name="force"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static void ViewKick(this Entity entity, int force, Vector3 source)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.viewkick, force, source);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Locks player's weapon onto an entity. Implies WeaponLockStart(), so this may be called to jump to a hard lock
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void WeaponLockFinalize(this Entity player, Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockfinalize, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Clear the player's weapon lock
        /// </summary>
        /// <returns></returns>
        public static void WeaponLockFree(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockfree);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// When set true, the player will be unable to fire thair lockon weapon, and will recieve a hint print telling them that there is an obstruction
        /// </summary>
        /// <param name="noClearance"></param>
        /// <returns></returns>
        public static void WeaponLockNoClearance(this Entity entity, bool noClearance)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlocknoclearance, noClearance);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Begins player's weapon lockon sequence (hud effects, etc). Will clear any existing hard lock. Use WeaponLockFinalize(this Entity entity, ) to complete lock
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void WeaponLockStart(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockstart);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// When set true, the player will be unable to fire their lockon weapons, and will recieve a hint print telling them that they are too close
        /// </summary>
        /// <param name="tooClose"></param>
        /// <returns></returns>
        public static void WeaponLockTargetTooClose(this Entity entity, bool tooClose)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlocktargettooclose, tooClose);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the player's view height
        /// </summary>
        /// <returns>Returns the player's view height as a float</returns>
        public static float GetPlayerViewHeight(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerviewheight);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the player's weapon that is in the primary slot
        /// </summary>
        /// <returns>Returns the name of the weapon in the player's primary slot</returns>
        public static string GetCurrentPrimaryWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentprimaryweapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the player is currently holding a dual wield weapon
        /// </summary>
        /// <returns>Returns true if the player is holding a dual wield weapon</returns>
        public static bool IsDualWielding(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isdualwielding);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the player is reloading
        /// </summary>
        /// <returns>Returns true if the player is reloading</returns>
        public static bool IsReloading(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isreloading);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the player is in the process of switching weapons
        /// </summary>
        /// <returns>Returns true if the player is switching to another weapon</returns>
        public static bool IsSwitchingWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isswitchingweapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the player is currently manning a turret
        /// </summary>
        /// <returns>Returns true if the player is manning a turret</returns>
        public static bool IsUsingTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isusingturret);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets the name that primary offhand toggle is set to
        /// </summary>
        /// <returns>Returns the name of the player's primary offhand class</returns>
        public static string GetOffhandPrimaryClass(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getoffhandprimaryclass);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the player's current primary offhand class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SetOffhandPrimaryClass(this Entity entity, string name)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setoffhandprimaryclass, name);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disables the use of offhand weapons (grenades, flashes)
        /// </summary>
        /// <returns></returns>
        public static void DisableOffhandWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableoffhandweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables the use of offhand weapons (grenades, flashes)
        /// </summary>
        /// <returns></returns>
        public static void EnableOffhandWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableoffhandweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disables weapon switching for the player
        /// </summary>
        /// <returns></returns>
        public static void DisableWeaponSwitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweaponswitch);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables weapon switching for the player
        /// </summary>
        /// <returns></returns>
        public static void EnableWeaponSwitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweaponswitch);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes the player unable to use things such as triggers, turrets, etc.
        /// </summary>
        /// <returns></returns>
        public static void DisableUsability(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableusability);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes the player able to use things such as triggers, turrets, etc.
        /// </summary>
        /// <returns></returns>
        public static void EnableUsability(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableusability);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetWhizBySpreads(this Entity entity, float x, float y, float z)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwhizbyspreads, x, y, z);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetWhizByRadii(this Entity entity, float x, float y, float z)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwhizbyradii, x, y, z);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetVolMod(this Entity entity, float vol, float overrideVol)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvolmod, vol, overrideVol);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the channel volume for the player(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SetChannelVolume(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setchannelvolume);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the movement scale that the player's crosshairs spread out/in while they are moving
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetAimSpreadMovementScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setaimspreadmovementscale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the scale of how much the player's screen gets thrown around when getting hurt
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetViewKickScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewkickscale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the scale of how much the player's screen gets thrown around when getting hurt
        /// </summary>
        /// <returns>Returns the scale value of how much the player's screen kicks when being hurt</returns>
        public static float GetViewKickScale(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getviewkickscale);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks whether the player can place a sentry in front of them as a valid position
        /// </summary>
        /// <returns>Returns 'result'(bool whether the player can place a sentry or not), 'origin'(The position of the placement, and 'angles'(The angles of the placement) all in an array</returns>
        public static Array CanPlayerPlaceSentry(this Entity entity)
        {
            throw new NotImplementedException();
            /*
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canplayerplacesentry);

            Vector3 origin = Function.GetReturns();
            Vector3 angles = Function.GetReturns();
            int canPlace = Function.GetReturns();
            Array ret;
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
             */
        }

        /// <summary>
        /// Checks whether the player can place a tank in front of them as a valid position
        /// </summary>
        /// <returns>Returns 'result'(bool whether the player can place a tank or not), 'origin'(The position of the placement, and 'angles'(The angles of the placement) all in an array</returns>
        public static Array CanPlayerPlaceTank(this Entity entity)
        {
            throw new NotImplementedException();
            /*
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canplayerplacetank);

            Vector3 origin = Function.GetReturns();
            Vector3 angles = Function.GetReturns();
            int canPlace = Function.GetReturns();
            Array ret;
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
             */
        }

        /// <summary>
        /// Sets the 'naked' vision for this player
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetNakedForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnakedforplayer, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetNakedForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnakedforplayer, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the visionset for this player when they have nightvision goggles equipped
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetNightForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnightforplayer, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetNightForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnightforplayer, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the visionset for this player while they are controlling a missile
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetMissileCamForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecamforplayer, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetMissileCamForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecamforplayer, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the visionset for this player when they are scoped into a thermal scope
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetThermalForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermalforplayer, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetThermalForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermalforplayer, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the visionset for this player when they are in pain/near death
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void VisionSetPainForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpainforplayer, vision);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void VisionSetPainForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpainforplayer, vision, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the weapon model of the player's current weapon
        /// </summary>
        /// <returns>Returns the model name of the player's current weapon</returns>
        public static string GetPlayerWeaponModel(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerweaponmodel);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the weapon model of the player's knife
        /// </summary>
        /// <returns>Returns the model name of the player's current knife</returns>
        public static string GetPlayerKnifeModel(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerknifemodel);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Updates the player's current player model according to their current loadout
        /// </summary>
        /// <returns></returns>
        public static void UpdatePlayerModelWithWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.updateplayermodelwithweapons);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the player can mantle at their current location
        /// </summary>
        /// <returns>Returns true if the player can mantle</returns>
        public static bool CanMantle(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canmantle);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Forces the player to mantle in their current spot regardless if they can
        /// </summary>
        /// <returns></returns>
        public static void ForceMantle(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forcemantle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on recoil scaling if off and sets the player's current recoil scaling factor
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static int Player_RecoilScaleOn(this Entity entity, int scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.player_recoilscaleon, scale);
            int ret = Convert.ToInt32(Function.GetReturns());
            return ret;
        }
        /// <summary>
        /// Turns off recoil scaling so that they use default values
        /// </summary>
        /// <returns></returns>
        public static void Player_RecoilScaleOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.player_recoilscaleoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Syncs this player's vision with another player's
        /// </summary>
        /// <returns></returns>
        public static void VisionSyncWithPlayer(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsyncwithplayer, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetEnterTime(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setentertime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets this player's GUID
        /// </summary>
        /// <returns>Returns the player's GUID</returns>
        public static string GetGUID(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getguid);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets this player's XUID
        /// </summary>
        /// <returns>Returns the player's XUID</returns>
        public static string GetXUID(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getxuid);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if this player is the host of the current game
        /// </summary>
        /// <returns>Returns true if this player is the host of the current game</returns>
        public static bool IsHost(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ishost);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets the player that this player is currently spectating
        /// </summary>
        /// <returns>Returns the player that this player is currently spectating</returns>
        public static Entity GetSpectatingPlayer(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getspectatingplayer);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static void PredictStreamPos(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.predictstreampos, origin, angles);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets display slot info for this player, used for card splashes such as 'YOU KILLED', 'KILLED YOU','SPECTATING'
        /// </summary>
        /// <param name="player"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static void SetCardDisplaySlot(this Entity entity, Entity player, int slot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcarddisplayslot, player, slot);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player's playercard title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static void SetCardTitle(this Entity entity, string title)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardtitle, title);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player's playercard icon
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void SetCardIcon(this Entity entity, string icon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardicon, icon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player's playercard nameplate(unused)
        /// </summary>
        /// <param name="nameplate"></param>
        /// <returns></returns>
        public static void SetCardNamePlate(this Entity entity, string nameplate)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardnameplate, nameplate);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Revives this player if they are in last stand or final stand
        /// </summary>
        /// <returns></returns>
        public static void LastStandRevive(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laststandrevive);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the default spectator starting position for this player
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static void SetSpectateDefaults(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setspectatedefaults, origin, angles);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the offset for the player's crosshair when in a third person view
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="angles"></param>
        /// <returns>Returns the offset for the player's crosshair when in a third person view</returns>
        public static float GetThirdPersonCrosshairOffset(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getthirdpersoncrosshairoffset);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Disables weapon pickup for this player
        /// </summary>
        /// <returns></returns>
        public static void DisableWeaponPickup(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweaponpickup);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables weapon pickup for this player
        /// </summary>
        /// <returns></returns>
        public static void EnableWeaponPickup(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweaponpickup);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="viewFraction"></param>
        /// <param name="rightArc"></param>
        /// <param name="leftArc"></param>
        /// <param name="topArc"></param>
        /// <param name="bottomArc"></param>
        /// <param name="collide"></param>
        /// <returns></returns>
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tag"></param>
        /// <param name="viewFraction"></param>
        /// <param name="rightArc"></param>
        /// <param name="leftArc"></param>
        /// <param name="topArc"></param>
        /// <param name="bottomArc"></param>
        /// <param name="collide"></param>
        /// <returns></returns>
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc, leftArc, topArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc, leftArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void PlayerLinkToBlend(this Entity player, Entity entity)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables setting an offset to any linked entities on this entity(TBD)
        /// </summary>
        /// <returns></returns>
        public static void PlayerLinkedOffsetEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedoffsetenable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disables setting an offset to any linked entities on this entity(TBD)
        /// </summary>
        /// <returns></returns>
        public static void PlayerLinkedOffsetDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedoffsetdisable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the z_near value for this player's view when the camera is linked to another entity
        /// </summary>
        /// <param name="zNear"></param>
        /// <returns></returns>
        public static void PlayerLinkedSetViewZNear(this Entity entity, float zNear)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedsetviewznear, zNear);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void PlayerLinkedSetUseBaseAngleForViewClamp(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedsetusebaseangleforviewclamp);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void LerpViewAngleClamp(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.lerpviewangleclamp);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public static void SetViewAngleResistance(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewangleresistance);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on thermal vision for this player
        /// </summary>
        /// <returns></returns>
        public static void ThermalVisionOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns off thermal vision for this player
        /// </summary>
        /// <returns></returns>
        public static void ThermalVisionOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on player target indicators so that enemy players have a red box around them
        /// </summary>
        /// <returns></returns>
        public static void ThermalVisionFOFOverlayOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionfofoverlayon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns off player target indicators
        /// </summary>
        /// <returns></returns>
        public static void ThermalVisionFOFOverlayOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionfofoverlayoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns on autospot so that all player names are visible
        /// </summary>
        /// <returns></returns>
        public static void AutospotOverlayOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.autospotoverlayon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns off autospot so that player names are only visible when looking at them
        /// </summary>
        /// <returns></returns>
        public static void AutospotOverlayOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.autospotoverlayoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set's a player's use hint and forces it to display. Use ForceUseHintOff() to remove it
        /// </summary>
        /// <param name="hint"></param>
        /// <returns></returns>
        public static void ForceUseHintOn(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forceusehinton, hint);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Removes any use hints on the player's screen
        /// </summary>
        /// <returns></returns>
        public static void ForceUseHintOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forceusehintoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this entity a soft entity(TBD)
        /// </summary>
        /// <returns></returns>
        public static Entity MakeSoft(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makesoft);
            //Utils.FuncCaller.ScriptStack.Clear();

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Makes this entity a hard entity
        /// </summary>
        /// <returns></returns>
        public static Entity MakeHard(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makehard);
            //Utils.FuncCaller.ScriptStack.Clear();

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Sets a flag for this entity to tell the game that this entity will remain exactly as it is when this function is called. This will disable any script interactivity with this entity
        /// </summary>
        /// <returns></returns>
        public static void WillNeverChange(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.willneverchange);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player's stance. Valid stances are 'prone', 'crouch', and 'stand'
        /// </summary>
        /// <param name="stance"></param>
        /// <returns></returns>
        public static void SetStance(this Entity entity, string stance)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setstance, stance);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stuns this player for the specified amount of time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void StunPlayer(this Entity entity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stunplayer, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Fades out any current shellshock for this player(TBD)
        /// </summary>
        /// <returns></returns>
        public static void FadeOutShellShock(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeoutshellshock);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the scale at which this player's vision blurs while moving
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetMotionBlurMoveScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurmovescale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the scale at which this player's vision blurs while looking around
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetMotionBlurTurnScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurturnscale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the scale at which this player's vision blurs while zooming in
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void SetMotionBlurZoomScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurzoomscale, scale);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a setting value from this player
        /// </summary>
        /// <param name="setting"></param>
        /// <returns>Returns the player's value of the given setting</returns>
        public static string GetPlayerSetting(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayersetting);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets data from this player's local stats(TBD)
        /// </summary>
        /// <returns>Returns the player's local value of the given stat</returns>
        public static string GetLocalPlayerProfileData(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getlocalplayerprofiledata);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets a stat on this player's local stat file
        /// </summary>
        /// <returns></returns>
        public static void SetLocalPlayerProfileData(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setlocalplayerprofiledata);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enables sounds to be heard from the camera position if this player's camera is somewhere else
        /// </summary>
        /// <returns></returns>
        public static void RemoteCameraSoundscapeOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecamerasoundscapeon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disables sounds to be heard from the camera position if this player's camera is somewhere else
        /// </summary>
        /// <returns></returns>
        public static void RemoteCameraSoundscapeOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecamerasoundscapeoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Jams this player's radar
        /// </summary>
        /// <returns></returns>
        public static void RadarJamOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.radarjamon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Un-jams this player's radar
        /// </summary>
        /// <returns></returns>
        public static void RadarJamOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.radarjamoff);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether this player is visible on heartbeat sensors or not
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public static void SetMotionTrackerVisible(this Entity entity, bool visible)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotiontrackervisible, visible);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets whether this player is visible on heartbeat sensors or not
        /// </summary>
        /// <returns>Returns true if this player is visible on heartbeat sensors</returns>
        public static bool GetMotionTrackerVisible(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmotiontrackervisible);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Sets a water sheet over the player's screen as if they submerged under water
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static void SetWaterSheeting(this Entity entity, int sheet, int duration)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwatersheeting, sheet, duration);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the weapon hud icon override for this player. This will override any icon in place of the player's current offhand and replace it with the given shader
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void SetWeaponHudIconOverride(this Entity entity, string icon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setweaponhudiconoverride, icon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the current offhand weapon hud override icon this player has
        /// </summary>
        /// <param name="visible"></param>
        /// <returns>Returns the name of the shader that this player's offhand icon override is set to</returns>
        public static string GetWeaponHudIconOverride(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponhudiconoverride);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets whether this player's screen is emp jammed
        /// </summary>
        /// <param name="jammed"></param>
        /// <returns></returns>
        public static void SetEMPJammed(this Entity entity, bool jammed)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setempjammed, jammed);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player's exponential fog values
        /// </summary>
        /// <param name="startDist"></param>
        /// <param name="halfwayDist"></param>
        /// <param name="RGB"></param>
        /// <param name="transitionTime"></param>
        /// <returns></returns>
        public static void PlayerSetExpFog(this Entity entity, float startDist, float halfwayDist, Vector3 RGB, float transitionTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playersetexpfog, startDist, halfwayDist, RGB.X, RGB.Y, RGB.Z, transitionTime);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks whether this player has the given item unlocked or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsItemUnlocked(this Entity entity, string item)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isitemunlocked, item);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets stats from the player's playerdata
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns the value of the data field</returns>
        public static Parameter GetPlayerData(this Entity entity, params Parameter[] data)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerdata, data);

            object ret = Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return new Parameter(ret);
        }

        /// <summary>
        /// Sets a data field in this player's playerdata
        /// </summary>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetPlayerData(this Entity entity, params Parameter[] data)
        {
            Function.SetEntRef(entity.EntRef);
            /*
            Parameter[] pass = new Parameter[data.Length + 1];
            pass[pass.Length - 1] = value;
            for (int i = 0; i > pass.Length-1; i++)
            {
                pass[i] = data[i];
            }
             */
            Function.Call(ScriptNames.FunctionList.setplayerdata, data);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if this player is currently using online data while offline
        /// </summary>
        /// <returns>Returns true if the player is using online data while offline</returns>
        public static bool IsUsingOnlineDataOffline(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isusingonlinedataoffline);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets this player's time since the last game they player, in seconds
        /// </summary>
        /// <returns>Returns the player's amount of time since their last game</returns>
        public static int GetRestedTime(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getrestedtime);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        ///
        public static int Send73Command(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.send73command_unk);
            //Utils.FuncCaller.ScriptStack.Clear();
            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sends the current leaderboard stats to the player(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SendLeaderboards(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sendleaderboards);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Forces this player to start their death animations, crediting the inflictor with a kill but not killing this player
        /// </summary>
        /// <param name="inflictor"></param>
        /// <param name="meansOfDeath"></param>
        /// <param name="hitLoc"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static void PlayerForceDeathAnim(this Entity entity, Entity inflictor, string meansOfDeath, string hitLoc, Vector3 direction)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerforcedeathanim, inflictor, meansOfDeath, hitLoc, direction);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Informs the game that this player is starting to ride an AC130
        /// </summary>
        /// <returns></returns>
        public static void StartAC130(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startac130);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Informs the game that this player has stopped riding an AC130
        /// </summary>
        /// <returns></returns>
        public static void StopAC130(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopac130);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if a player can spawn at this position
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Returns true if a player can spawn at this position</returns>
        public static bool CanSpawn(this Entity entity, Vector3 origin)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canspawn, entity, origin);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Write a line to this player's screen.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void IPrintLn(this Entity entity, string message)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_iprintln, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Write a bold line to this player's screen.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void IPrintLnBold(this Entity entity, string message)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_iprintlnbold, message);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Hides a visible player
        /// </summary>
        /// <returns></returns>
        public static void PlayerHide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerhide);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the player is a splitscreen player
        /// </summary>
        /// <returns>Returns true if the player is a splitscreen player</returns>
        public static bool IsSplitScreenPlayer(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issplitscreenplayer);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the player is the primary splitscreen player
        /// </summary>
        /// <returns>Returns true if the player is the primary splitscreen player</returns>
        public static bool IsSplitScreenPlayerPrimary(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issplitscreenplayerprimary);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Updates values of the given leaderboard stat from the leaderboard tracker for this player
        /// </summary>
        /// <returns></returns>
        public static void TrackerUpdate(this Entity entity, string stat, int value)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.trackerupdate, stat, value);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Causes player models to be drawn as if they are seen in thermal mode
        /// </summary>
        /// <returns></returns>
        public static void ThermalDrawEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermaldrawenable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Turns off drawing player models in thermal mode
        /// </summary>
        /// <returns></returns>
        public static void ThermalDrawDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermaldrawdisable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region precache
        /// <summary>
        /// Precache a head icon
        /// </summary>
        /// <param name="headicon"></param>
        /// <returns></returns>
        public static void PreCacheHeadIcon(string headicon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheheadicon, headicon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches a given item. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static void PreCacheItem(string item)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheitem, item);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches a material to be used as an indicator during location selection on the map
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static void PreCacheLocationSelector(string material)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachelocationselector, material);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches this menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static void PreCacheMenu(string menu)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachemenu, menu);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the given model. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void PreCacheModel(string model)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachemodel, model);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the given rumble. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="rumble"></param>
        /// <returns></returns>
        public static void PreCacheRumble(string rumble)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacherumble, rumble);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the given shader. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static void PreCacheShader(string material)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheshader, material);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the shellshock effect. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="shellshock"></param>
        /// <returns></returns>
        public static void PreCacheShellShock(string shellshock)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheshellshock, shellshock);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches a status icon
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void PreCacheStatusIcon(string icon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachestatusicon, icon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the given string. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void PreCacheString(string text)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachestring, text);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precaches the weapon info structure for a vehicle. It must be called before any wait statements in the level script
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static void PreCacheVehicle(string vehicle)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachevehicle, vehicle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Look up a row in a table and pull out a particular column from that row in an IString
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="columnReturn"></param>
        /// <returns>Returns the value pulled from the given row and column as an IString</returns>
        public static string TableLookupIString(string filename, int column, Parameter value, int columnReturn)//Maybe return this as an istring(short) or convert it to string and return
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tablelookupistring, filename, column, value, columnReturn);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Look up a row in a table and pull out a particular column from that row
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="columnReturn"></param>
        /// <returns>Returns the value pulled from the given row and column</returns>
        public static string TableLookup(string filename, int column, Parameter value, int columnReturn)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tablelookup, filename, column, value, columnReturn);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Precaches a thermal effect for use on the specified tag
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static void PreCacheFXTeamThermal(int effect, string tag)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachefxteamthermal, effect, tag);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precache a minimap icon
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void PreCacheMiniMapIcon(string icon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheminimapicon, icon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precache an <see cref="Animation"/>
        /// </summary>
        /// <param name="anim"></param>
        /// <returns></returns>
        public static void PreCacheMpAnim(string anim)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precachempanim, anim);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Precache a leaderboard definition
        /// </summary>
        /// <param name="leaderboard"></param>
        /// <returns></returns>
        public static void PreCacheLeaderboards(string leaderboard)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheleaderboards, leaderboard);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Look up a row and column in a table and pull out that particular value
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Returns the value pulled from the given row and column</returns>
        public static string TableLookupByRow(string filename, int row, int column)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tablelookupbyrow, filename, row, column);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Look up a row and column in a table and pull out a particular value from that row in an IString
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Returns the value pulled from the given row and column as an IString</returns>
        public static string TableLookupIStringByRow(string filename, int row, int column)//Maybe return this as an istring(short) or convert it to string and return
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tablelookupistringbyrow, filename, row, column);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Look up a column in a table and gets the row number of the given value
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns>Returns the row number pulled from the given column</returns>
        public static int TableLookupRowNum(string filename, int column, Parameter value)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tablelookuprownum, filename, column, value);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Precaches a weapon for turret use.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void PreCacheTurret(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.precacheturret, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region rumble
        /// <summary>
        /// Plays a looping controller rumble on the given player
        /// </summary>
        /// <param name="rumble"></param>
        /// <returns></returns>
        public static void PlayRumbleLoopOnEntity(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumblelooponentity, rumble);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays a looping rumble at a given position
        /// </summary>
        /// <param name="rumble"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static void PlayRumbleLoopOnPosition(string rumble, Vector3 position)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumblelooponposition, rumble, position);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays a rumble on the given entity
        /// </summary>
        /// <param name="rumble"></param>
        /// <returns></returns>
        public static void PlayRumbleOnEntity(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumbleonentity, rumble);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays a rumble at a given position
        /// </summary>
        /// <param name="rumble"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static void PlayRumbleOnPosition(string rumble, Vector3 position)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumbleonposition, rumble, position);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stops all of the current rumbles
        /// </summary>
        /// <returns></returns>
        public static void StopAllRumbles()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopallrumbles);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Quits the playing of a particular rumble on a player
        /// </summary>
        /// <param name="rumble"></param>
        /// <returns></returns>
        public static void StopRumble(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoprumble, rumble);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region sentient
        /// <summary>
        /// Gets the position of the eye for an AI or player
        /// </summary>
        /// <returns>Returns the position of the eye for the given AI or Player</returns>
        public static Vector3 GetEye(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.geteye);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks whether the entity is alive
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns true if the entity is alive</returns>
        public static bool IsAlive(Entity entity)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isalive, entity);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the entity is a player
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns true if the entity is a player</returns>
        public static bool IsPlayer(Entity entity)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isplayer, entity);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region sound
        /// <summary>
        /// Play the given piece of ambient sound
        /// </summary>
        /// <param name="ambient"></param>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void AmbientPlay(string ambient)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ambientplay, ambient);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void AmbientPlay(string ambient, float fade)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ambientplay, ambient, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stop all ambient sounds (excluding the music track)
        /// </summary>
        /// <param name="fade"></param>
        /// <returns></returns>
        public static void AmbientStop()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ambientstop);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void AmbientStop(float fade)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ambientstop, fade);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play a sound as a loop
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlayLoopSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playloopsound, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play a sound alias as if coming from the entity
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlaySound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsound, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play a sound alias as if coming from the entity, as a master sound
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlaySoundAsMaster(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsoundasmaster, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play a sound alias as if coming from the entity, so that only one player can hear it
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlaySoundToPlayer(this Entity entity, string sound, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsoundtoplayer, sound, player);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Play a sound alias as if coming from the entity, so that only one team can hear it
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static void PlaySoundToTeam(this Entity entity, string sound, string team, Entity ignorePlayer = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignorePlayer != null) Function.Call(ScriptNames.FunctionList.playsoundtoteam, sound, team, ignorePlayer);
            else Function.Call(ScriptNames.FunctionList.playsoundtoteam, sound, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the sound alias exists
        /// </summary>
        /// <param name="alias"></param>
        /// <returns>Returns true if the sound alias exists</returns>
        public static bool SoundExists(string alias)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.soundexists, alias);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Stop a looping sound
        /// </summary>
        /// <returns></returns>
        public static void StopLoopSound(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoploopsound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stop all sounds on an entity. You must have a wait between Stopstrings() and Delete() or the sound will not stop
        /// </summary>
        /// <returns></returns>
        public static void StopSound(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopsounds);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Plays a <see cref="string"/> at a world position
        /// </summary>
        /// <param name="sound"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static void PlaySoundAtPos(Vector3 origin, string sound)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsoundatpos, origin, sound);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the current ambience track for the ac130
        /// </summary>
        /// <param name="ambience"></param>
        /// <returns></returns>
        public static void SetAC130Ambience(string ambience)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setac130ambience, ambience);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /*
        /// <summary>
        /// Spawns a loop sound at the given position(TBD)
        /// </summary>
        /// <param name="sound"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static void SpawnLoopSound(string sound, Vector3 origin)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnloopsound, sound, origin);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        */
        #endregion

        #region spawn
        /// <summary>
        /// Raises a spawn point up to make sure it's not in the ground, then drops it back down onto the ground
        /// </summary>
        /// <returns></returns>
        public static void PlaceSpawnPoint(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.placespawnpoint);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if the passed in origin would telefrag a player if another player was spawned there
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Returns true if the passed in origin would telefrag a player if another player was spawned there</returns>
        public static bool PositionWouldTelefrag(Vector3 position)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.positionwouldtelefrag, position);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Spawns a new entity
        /// </summary>
        /// <param name="classname"></param>
        /// <param name="origin"></param>
        /// <returns>Returns a reference to the new entity</returns>
        public static Entity Spawn(string classname, Vector3 origin)
        {
            Function.Call(ScriptNames.FunctionList.spawn, classname, origin);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Spawns a new entity
        /// </summary>
        /// <param name="classname"></param>
        /// <param name="origin"></param>
        /// <param name="flags"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <returns>Returns a reference to the new entity</returns>
        public static Entity Spawn(string classname, Vector3 origin, int flags, int radius, int height)
        {
            Function.Call(ScriptNames.FunctionList.spawn, classname, origin, flags, radius, height);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Allocates a structure
        /// </summary>
        /// <returns>Returns a reference to the new structure as an <see cref="Entity"></see>"/></returns>
        public static Entity SpawnStruct()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnstruct);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Spawns a new turret
        /// </summary>
        /// <param name="classname"></param>
        /// <param name="origin"></param>
        /// <param name="weapon"></param>
        /// <returns>Returns a reference to the new turret</returns>
        public static Entity SpawnTurret(string classname, Vector3 origin, string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnturret, classname, origin, weapon);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Spawns a new vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <param name="targetname"></param>
        /// <param name="vehicleType"></param>
        /// <param name="origin"></param>
        /// <param name="angles"></param>
        /// <returns>Returns a reference to the new vehicle</returns>
        public static Entity SpawnVehicle(string model, string targetname, string vehicleType, Vector3 origin, Vector3 angles, Entity owner)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnvehicle, model, targetname, vehicleType, origin, angles, owner);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Spawns this player at the specified position as if they are respawning
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static void Spawn(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_spawn, origin, angles);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Spawns a new plane entity
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="classname"></param>
        /// <param name="origin"></param>
        /// <param name="friendlyIcon"></param>
        /// <param name="enemyIcon"></param>
        /// <returns>Returns a reference to the new plane</returns>
        public static Entity SpawnPlane(Entity owner, string classname, Vector3 origin, string friendlyIcon, string enemyIcon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnplane, owner, classname, origin, friendlyIcon, enemyIcon);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Spawns a new helicopter entity
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="pathStart"></param>
        /// <param name="forward"></param>
        /// <param name="vehicle"></param>
        /// <param name="model"></param>
        /// <returns>Returns a reference to the new helicopter</returns>
        public static Entity SpawnHelicopter(Entity owner, Vector3 pathStart, Vector3 forward, string vehicle, string model)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnhelicopter, owner, pathStart, forward, vehicle, model);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Creates a missile attractor on an enttiy
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strength"></param>
        /// <param name="range"></param>
        /// <returns>Returns a reference to the new attractor</returns>
        public static Entity CreateAttractorEnt(Entity entity, int strength, int range)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.createattractorent, entity, strength, range);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Creates a missile attractor on a world position
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="strength"></param>
        /// <param name="range"></param>
        /// <returns>Returns a reference to the new attractor</returns>
        public static Entity CreateAttractorOrigin(Vector3 origin, int strength, int range)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.createattractororigin, origin, strength, range);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Creates a missile repulsor on an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strength"></param>
        /// <param name="range"></param>
        /// <returns>Returns a reference to the new repulsor</returns>
        public static Entity CreateRepulsorEnt(Entity entity, int strength, int range)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.createrepulsorent, entity, strength, range);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Creates a missile repulsor on a world position
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="strength"></param>
        /// <param name="range"></param>
        /// <returns>Returns a reference to the new repulsor</returns>
        public static Entity CreateRepulsorOrigin(Vector3 origin, int strength, int range)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.createrepulsororigin, origin, strength, range);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion

        #region string
        /// <summary>
        /// Gets the substring of characters >= startIndex and endIndex. endIndex is optional
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns>Returns the substring of characters >= startIndex and endIndex</returns>
        public static string GetSubStr(string text, int startIndex, int endIndex = -1)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getsubstr, text, startIndex, endIndex);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if subString is a substring of text. Case sensitive
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subString"></param>
        /// <returns>Returns true if the passed in subString is a substring of text</returns>
        public static bool IsSubStr(string text, string subString)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issubstr, text, subString);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Tokenizes 'text' by the delimiters 'delim'
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delim"></param>
        /// <returns>Returns the array of string tokens</returns>
        public static Array StrTok(string text, string delim)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the passed in string to a lower case string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Returns the passed in string in lower case</returns>
        public static string ToLower(string text)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.tolower, text);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if endString is the ending string of text. Case sensitive
        /// </summary>
        /// <param name="text"></param>
        /// <param name="endString"></param>
        /// <returns>Returns true if the passed in endString is the ending string of text</returns>
        public static bool IsEndStr(string text, string endString)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isendstr, text, endString);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Compares two strings to see if they are the same
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>Returns true if the two strings are equal</returns>
        public static bool StriCmp(string str1, string str2)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stricmp, str1, str2);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region system
        /// <summary>
        /// Prints to the server log file
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void LogPrint(string text)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.logprint, text);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Writes a string to the server log file
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void LogString(string text)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.logstring_0, text);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        /*
        /// <summary>
        /// Writes a string to the server log file
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void LogString_0(string text)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.logstring_0, text);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        */

        /// <summary>
        /// Resets the infinite loop check timer, to prevent an incorrect infinite loop error when a lot of script must be run
        /// </summary>
        /// <returns></returns>
        public static void ResetTimeout()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.resettimeout);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Depricated function, does nothing
        /// </summary>
        /// <returns></returns>
        public static void SetArchive()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setarchive);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region team
        /// <summary>
        /// Gets the player's team as assigned by matchmaking
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns the player's assigned team. 0 = No Team, 1 = Axis, 2 = Allies, 3 = Spectator</returns>
        public static int GetAssignedTeam(Entity player)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getassignedteam, player);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the number of players still alive on a given team
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns the number of players still alive on the given team</returns>
        public static int GetTeamPlayersAlive(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getteamplayersalive, team);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets whether a team has radar or not
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns true if the given team has radar</returns>
        public static bool GetTeamRadar(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getteamradar, team);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Get a team's score
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns the given team's score</returns>
        public static int GetTeamScore(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getteamscore, team);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Set whether a team has radar or not
        /// </summary>
        /// <param name="team"></param>
        /// <param name="availability"></param>"
        /// <returns></returns>
        public static void SetTeamRadar(string team, bool availability)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setteamradar, team, availability);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set a team's score
        /// </summary>
        /// <param name="team"></param>
        /// <param name="score"></param>"
        /// <returns></returns>
        public static void SetTeamScore(string team, int score)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setteamscore, team, score);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a player's current team rank
        /// </summary>
        /// <param name="player"></param>
        /// <param name="clientID"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static void SetPlayerTeamRank(Entity player, int clientID, int rank)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerteamrank, player, clientID, rank);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets a team's radar strength
        /// </summary>
        /// <param name="team"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        public static void SetTeamRadarStrength(string team, int strength)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setteamradarstrength, team, strength);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets a team's radar strength
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns the team's radar strength</returns>
        public static int GetTeamRadarStrength(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getteamradarstrength, team);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Blocks a team's radar
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void BlockTeamRadar(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.blockteamradar, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Unblocks a team's radar
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void UnBlockTeamRadar(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.unblockteamradar, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if a team's radar is blocked
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Returns true if the team's radar is blocked</returns>
        public static bool IsTeamRadarBlocked(string team)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isteamradarblocked, team);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region trace
        /// <summary>
        /// Allows script to do a point trace with MASK_SHOT
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="hitCharacters"></param>
        /// <param name="ignore"></param>
        /// <returns>Returns hit position, hit entity, and hit surface normal in an array</returns>
        public static Array BulletTrace(Vector3 start, Vector3 end, bool hitCharacters, Entity ignore)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows script to do a point trace with MASK_SHOT
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="hitCharacters"></param>
        /// <param name="ignore"></param>
        /// <returns>Returns true if trace complete, else returns false</returns>
        public static bool BulletTracePassed(Vector3 start, Vector3 end, bool hitCharacters, Entity ignore = null)
        {
            //Function.SetEntRef(entity.EntRef);
            if (ignore != null) Function.Call(ScriptNames.FunctionList.bullettracepassed, start, end, hitCharacters, ignore);
            else Function.Call(ScriptNames.FunctionList.bullettracepassed, start, end, hitCharacters);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Determines how much the entity can be damaged from the given position, using the same check that is used by grenades. Performs multiple damage traces and returns an approximation to how much of the entity is damageable from the given point (between 0 and 1). In SinglePlayer this will always be 1 if the entity is partially damageable.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Returns the approximation of how much of the entity is damageable as a float</returns>
        public static float DamageConeTrace(this Entity entity, Vector3 origin, Entity ignore = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignore != null) Function.Call(ScriptNames.FunctionList.damageconetrace, origin, ignore);
            else Function.Call(ScriptNames.FunctionList.damageconetrace, origin);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Physics trace, ignoring characters
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Returns the endpos vector of the trace</returns>
        public static Vector3 PhysicsTrace(Vector3 start, Vector3 end)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicstrace, start, end);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Physics trace using player capsule size, ignoring characters
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Returns the endpos vector of the trace</returns>
        public static Vector3 PlayerPhysicsTrace(Vector3 start, Vector3 end)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerphysicstrace, start, end);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Determines how much the entity can be seen from the given position, using the same check that is used by grenades. Performs multiple sight traces and returns an approximation to how much of the entity is visible from the given point (between 0 and 1). In SinglePlayer this will always be 1 if the entity is partially visible.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="ignore"></param>
        /// <returns>Returns the approximation of how much of the entity is visible from the given position as a float</returns>
        public static float SightConeTrace(this Entity entity, Vector3 position, Entity ignore = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignore != null) Function.Call(ScriptNames.FunctionList.sightconetrace, position, ignore);
            else Function.Call(ScriptNames.FunctionList.sightconetrace, position);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Allows script to do a point trace with MASK_OPAQUE_AI
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="hitCharacters"></param>
        /// <param name="ignore"></param>
        /// <returns>Returns true if trace complete, else returns false</returns>
        public static bool SightTracePassed(Vector3 start, Vector3 end, bool hitCharacters, params Entity[] ignore)
        {
            //Function.SetEntRef(entity.EntRef);
            if (ignore.Length == 0) Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters);
            else if (ignore.Length == 1)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0]);
            else if (ignore.Length == 2)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0], ignore[1]);
            else if (ignore.Length == 3)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0], ignore[1], ignore[2]);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Traces sight from a spawnpoint to a location to determine how much of the location can be seen from the given spawn
        /// </summary>
        /// <param name="spawnpoint"></param>
        /// <param name="origin"></param>
        /// <param name="end"></param>
        /// <returns>Returns the value of how much the player can be seen from this spawn as a float</returns>
        public static float SpawnSightTrace(Entity spawnpoint, Vector3 origin, Vector3 end)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.spawnsighttrace, spawnpoint, origin, end);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Physics trace, ignoring characters
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Returns the hit normal of the trace</returns>
        public static Parameter PhysicsTraceNormal(Vector3 start, Vector3 end)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicstracenormal, start, end);

            Parameter ret = new Parameter(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates an average normal out of the given normals
        /// </summary>
        /// <param name="normals"></param>
        /// <returns>Returns the average normal of the given normals</returns>
        public static float AverageNormal(Array normals)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            /*
            Function.Call(ScriptNames.FunctionList.averagenormal, normals);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
             */
        }

        /// <summary>
        /// Checks if the given origin is within the player's reticle circle
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Returns true if the given origin is within the player's reticle circle, false otherwise</returns>
        public static bool WorldPointInReticle_Circle(this Entity entity, Vector3 origin, int width, int height)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.worldpointinreticle_circle, origin, width, height);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region trigger
        /// <summary>
        /// Claim a single user trigger
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public static void ClientClaimTrigger(this Entity entity, Entity trigger)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clientclaimtrigger, trigger);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Release a single user trigger
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public static void ClientReleaseTrigger(this Entity entity, Entity trigger)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clientreleasetrigger, trigger);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Release a currently claimed trigger
        /// </summary>
        /// <returns></returns>
        public static void ReleaseClaimedTrigger(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.releaseclaimedtrigger);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        #endregion

        #region turret
        /// <summary>
        /// Clears the current target for this turret
        /// </summary>
        /// <returns></returns>
        public static void ClearTargetEntity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetentity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the current target of this turret
        /// </summary>
        /// <returns>Returns the target entity of the turret</returns>
        public static Entity GetTurretTarget(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getturrettarget);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks whether this turret is firing. Must be called on a turret
        /// </summary>
        /// <returns>Returns true if this turret is firing</returns>
        public static bool IsFiringTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isfiringturret);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Restores the pitch of the turret when it drops to the ground. Recalculates based on current collision environment. Use this if you move a turret and need to reconfigure.
        /// </summary>
        /// <returns></returns>
        public static void RestoreDefaultDropPitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.restoredefaultdroppitch);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the spread of this turret when used by an AI
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        public static void SetAISpread(this Entity entity, float spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setaispread, spread);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the amount that the turret can pivot down
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void SetBottomArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setbottomarc, angle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the time that a turret takes to converge to it's target, on either the pitch or yaw planes
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>"
        /// <returns></returns>
        public static void SetConvergenceTime(this Entity entity, float time, string type = "yaw")
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setconvergencetime, time, type);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the default drop pitch that the turret attempts to return to when it is not in use
        /// </summary>
        /// <param name="pitch"></param>
        /// <returns></returns>
        public static void SetDefaultDropPitch(this Entity entity, float pitch)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdefaultdroppitch, pitch);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the amount that the turret can move to the left
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void SetLeftArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setleftarc, angle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the mode of a turret
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static void SetMode(this Entity entity, string mode)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmode, mode);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the spread of this turret when used by the player
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        public static void SetPlayerSpread(this Entity entity, float spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerspread, spread);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the amount that the turret can move to the right
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void SetRightArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setrightarc, angle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the time that a turret uses supressing fire after losing sight of an enemy
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void SetSupressionTime(this Entity entity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setsuppressiontime, time);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the target of this turret
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void SetTargetEntity(this Entity entity, Entity target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetentity, target);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Set the amount that the turret can pivot up
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void SetTopArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settoparc, angle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the team of a turret
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static void SetTurretTeam(this Entity entity, string team)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretteam, team);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Shoots a turret
        /// </summary>
        /// <returns></returns>
        public static void ShootTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shootturret);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Starts a turret firing
        /// </summary>
        /// <returns></returns>
        public static void StartFiring(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startfiring);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stops a turret firing
        /// </summary>
        /// <returns></returns>
        public static void StopFiring(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopfiring);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Disable a turret's ability to fire
        /// </summary>
        /// <returns></returns>
        public static void TurretFireDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.turretfiredisable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enable a turret's ability to fire
        /// </summary>
        /// <returns></returns>
        public static void TurretFireEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.turretfireenable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Starts spinning the barrel of a turret
        /// </summary>
        /// <returns></returns>
        public static void StartBarrelSpin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startbarrelspin);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Stops spinning the barrel of a turret
        /// </summary>
        /// <returns></returns>
        public static void StopBarrelSpin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopbarrelspin);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the rate at which this turret's barrel is spinning
        /// </summary>
        /// <returns>Returns the rate at which this turret's barrel is spinning</returns>
        public static float GetBarrelSpinRate(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getbarrelspinrate);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets this player to start controlling a turret. Any player input will be directed to the turret
        /// </summary>
        /// <param name="turret"></param>
        /// <returns></returns>
        public static void RemoteControlTurret(this Entity entity, Entity turret)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolturret, turret);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player to no longer control a currently controlled turret
        /// </summary>
        /// <param name="turret"></param>
        /// <returns></returns>
        public static void RemoteControlTurretOff(this Entity entity, Entity turret)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolturretoff, turret);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the owner of this turret
        /// </summary>
        /// <returns>Returns the owner of this turret</returns>
        public static Entity GetTurretOwner(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getturretowner);

            Entity ret = (Entity)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Sets the owner of this sentry
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static void SetSentryOwner(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setsentryowner, owner);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the passed in player as the carrier of this sentry. This will cause the sentry to lock to the player for placement
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public static void SetSentryCarrier(this Entity entity, Entity carrier)
        {
            Function.SetEntRef(entity.EntRef);
            if (carrier != null) Function.Call(ScriptNames.FunctionList.setsentrycarrier, carrier);
            else Function.Call(ScriptNames.FunctionList.setsentrycarrier);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether this turret is visible on the minimap or not
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public static void SetTurretMinimapVisible(this Entity entity, bool visible)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretminimapvisible, visible);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Snaps this turret to it's currently assigned target entity(TBD)
        /// </summary>
        /// <returns></returns>
        public static void SnapToTargetEntity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.snaptotargetentity);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the percent that a turret converges to it's target based on height(TBD)
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static void SetConvergenceHeightPercent(this Entity entity, float percent)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setconvergenceheightpercent, percent);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this turret solid so that players can collide with it
        /// </summary>
        /// <returns></returns>
        public static void MakeTurretSolid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretsolid);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this turret operable by players or AI
        /// </summary>
        /// <returns></returns>
        public static void MakeTurretOperable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretoperable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Makes this turret inoperable
        /// </summary>
        /// <returns></returns>
        public static void MakeTurretInOperable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretinoperable);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the accuracy of this turret while using it(TBD)
        /// </summary>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public static void SetTurretAccuracy(this Entity entity, float accuracy)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretaccuracy, accuracy);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets the delay on the auto rotation of this turret(TBD)
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static void SetAutoRotationDelay(this Entity entity, float delay)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setautorotationdelay, delay);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets whether this turret should wait for it's mode to change or not(TBD)
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        public static void SetTurretModeChangeWait(this Entity entity, bool wait)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretmodechangewait, wait);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player to start controlling a vehicle. Any player input will be directed to the vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static void RemoteControlVehicle(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolvehicle, vehicle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player to stop controlling a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static void RemoteControlVehicleOff(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolvehicleoff, vehicle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Checks if this player is firing a vehicle's turret
        /// </summary>
        /// <returns>Returns true if the player is firing a vehicle's turret</returns>
        public static bool IsFiringVehicleTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isfiringvehicleturret);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Sets this player to start controlling a vehicle and be able to fire the vehicle's attached turret
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static void DriveVehicleAndControlTurret(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.drivevehicleandcontrolturret, vehicle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Sets this player to stop controlling a vehicle and it's turret
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static void DriveVehicleAndControlTurretOff(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.drivevehicleandcontrolturretoff, vehicle);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Gets the current mode of this turret
        /// </summary>
        /// <returns>Returns this turret's current mode</returns>
        public static string GetMode(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmode);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the game can spawn another turret
        /// </summary>
        /// <returns>Returns true if the game can spawn another turret</returns>
        public static bool CanSpawnTurret()
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canspawnturret);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }
        #endregion

        #region var
        /// <summary>
        /// Checks whether this entity/variable is defined
        /// </summary>
        /// <param name="variable"></param>
        /// <returns>Returns true if this entity/variable is defined</returns>
        public static bool IsDefined(Parameter variable)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isdefined, variable);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks whether this entity/variable is a string
        /// </summary>
        /// <param name="variable"></param>
        /// <returns>Returns true if this entity/variable is a string</returns>
        public static bool IsString(Parameter variable)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isstring, variable);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets an Array consisting of the keys in the input array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Returns an array consisting of the keys in the given array</returns>
        public static Array GetArrayKeys(Array array)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            //Function.Call(ScriptNames.FunctionList.getarraykeys, array);

            //Array ret;
            //string key = Function.GetReturns();
            ////Utils.FuncCaller.ScriptStack.Clear();
            //return ret;
        }

        /// <summary>
        /// Gets the first array keyin an array(TBD)
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Returns the first array key  in the array</returns>
        public static string GetFirstArrayKey(Array array)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            //Function.Call(ScriptNames.FunctionList.getfirstarraykey, array);

            //string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            //return ret;
        }

        /// <summary>
        /// Gets the next array key after the given index in an array(TBD)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns>Returns the next array key after the given index in the array</returns>
        public static string GetNextArrayKey(Array array, int index)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            //Function.Call(ScriptNames.FunctionList.getnextarraykey, array, index);

            //string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            //return ret;
        }

        /// <summary>
        /// Sorts the given array in accordance to distance from the given position
        /// </summary>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <returns>Returns the newly sorted array</returns>
        public static Array SortByDistance(Array array, Vector3 position)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region vector
        /// <summary>
        /// Calculates the forward vector corresponding to a set of angles
        /// </summary>
        /// <param name="angles"></param>
        /// <returns>Returns the forward vector corresponding to a set of angles</returns>
        public static Vector3 AnglesToForward(Vector3 angles)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.anglestoforward, angles);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the right vector corresponding to a set of angles
        /// </summary>
        /// <param name="angles"></param>
        /// <returns>Returns the right vector corresponding to a set of angles</returns>
        public static Vector3 AnglesToRight(Vector3 angles)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.anglestoright, angles);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the up vector corresponding to a set of angles
        /// </summary>
        /// <param name="angles"></param>
        /// <returns>Returns the up vector corresponding to a set of angles</returns>
        public static Vector3 AnglesToUp(Vector3 angles)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.anglestoup, angles);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Tests which of two points is the closest
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns>Returns true if pointA is closer to the reference than pointB</returns>
        public static bool Closer(Vector3 reference, Vector3 pointA, Vector3 pointB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closer, reference, pointA, pointB);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Reorients anglesB to anglesA
        /// </summary>
        /// <param name="anglesA"></param>
        /// <param name="anglesB"></param>
        /// <returns>Returns anglesB reoriented by anglesA</returns>
        public static Vector3 CombineAngles(Vector3 anglesA, Vector3 anglesB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.combineangles, anglesA, anglesB);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the distance between two points
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns>Returns the distance between the two points</returns>
        public static float Distance(Vector3 pointA, Vector3 pointB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.distance, pointA, pointB);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the distance between two points, ignores height difference
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns>Returns the distance between the two points, ignoring height difference</returns>
        public static float Distance2D(Vector3 pointA, Vector3 pointB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.distance2d, pointA, pointB);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the squared distance between two points. This is cheaper than the actual distance as it doesn't involve a square root
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns>Returns the squared distance between the two points</returns>
        public static float DistanceSquared(Vector3 pointA, Vector3 pointB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.distancesquared, pointA, pointB);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the length of the given vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Returns the length of the given vector</returns>
        public static float Length(Vector3 vector)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.length);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the squared length for the given vector. This is cheaper than the actual vector length as it doesn't involve a square root
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Returns the squared length of the given vector</returns>
        public static float LengthSquared(Vector3 vector)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.lengthsquared, vector);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates the dot product of two vectors
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns>Returns the dot product of the two vectors</returns>
        public static float VectorDot(Vector3 pointA, Vector3 pointB)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectordot, pointA, pointB);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Linear interpolates between two vectors
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="fraction"></param>
        /// <returns>Returns the current interpolated position at fraction</returns>
        public static Vector3 VectorLerp(Vector3 from, Vector3 to, float fraction)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectorlerp, from, to, fraction);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates a normalized copy of this vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Returns the normalized copy of the given vector</returns>
        public static Vector3 VectorNormalize(Vector3 vector)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectornormalize, vector);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates a set of angles corresponding to the given vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Returns the angles corresponding to the given vector</returns>
        public static Vector3 VectorToAngles(Vector3 vector)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectortoangles, vector);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates a yaw value corresponding to the given vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Returns the angles corresponding to the given vector</returns>
        public static float VectorToYaw(Vector3 vector)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vectortoyaw, vector);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the closest point in bounds of the entity from the passed in position
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Returns the closest point in bounds from the given position</returns>
        public static Vector3 GetPointInBounds(this Entity entity, Vector3 point)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getpointinbounds, point);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the normal ground position of the given position
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Returns the ground position at the given coordinates</returns>
        public static Vector3 GetGroundPosition(Vector3 origin, float radius)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        public static Vector3 GetGroundPosition(Vector3 origin, float radius, float traceDistance)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius, traceDistance);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        public static Vector3 GetGroundPosition(Vector3 origin, float radius, float traceDistance, float traceHeight)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius, traceDistance, traceHeight);

            Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Calculates an average point out of the given points
        /// </summary>
        /// <param name="points"></param>
        /// <returns>Returns the average point of the given points</returns>
        public static Vector3 AveragePoint(Array points)
        {
            throw new NotImplementedException();
            //Function.SetEntRef(entity.EntRef);
            //Function.Call(ScriptNames.FunctionList.averagepoint, points);

            //Vector3 ret = (Vector3)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            //return ret;
        }
        #endregion

        #region weapon
        /// <summary>
        /// Disable grenade damage for damage triggers
        /// </summary>
        /// <returns></returns>
        public static void DisableGrenadeTouchDamage(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disablegrenadetouchdamage);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Enable grenade damage for damage triggers
        /// </summary>
        /// <returns></returns>
        public static void EnableGrenadeTouchDamage(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enablegrenadetouchdamage);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Get the remaining ammo
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the remaining ammo in the given weapon</returns>
        public static int GetAmmoCount(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getammocount, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get the name of the weapon model used for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the name of the weapon model used for the given weapon</returns>
        public static string GetWeaponModel(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponmodel, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        public static string GetWeaponModel(string weapon, int variant)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponmodel, weapon, variant);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        /*
        public static int GetWeaponIndexForName(string name)
        {
            Function.Call(ScriptNames.FunctionList.precacheturret, name);

            int ret = (int)Function.GetReturns();
            return ret;
        }
        */

        /// <summary>
        /// Get the names of the weapon's current hide tags.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the names of the weapon's current hide tags</returns>
        public static int GetWeaponHideTags(string weapon, int variant = 0)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponhidetags, weapon, variant);

            int ret = (int)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Checks if the weapon is clip only
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon is clip only</returns>
        public static bool IsWeaponClipOnly(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isweaponcliponly, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Checks if the weapon has timed detonation (e.g. frag/smoke grenades)
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon has a timed detonation</returns>
        public static bool IsWeaponDetonationTimed(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isweapondetonationtimed, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Sets the ammo amount for a weapon item entity (lying on the ground)
        /// </summary>
        /// <param name="clipAmmo"></param>
        /// <param name="reserveAmmo"></param>
        /// <param name="altWeapon"></param>
        /// <returns></returns>
        public static void ItemWeaponSetAmmo(this Entity entity, int clipAmmo, int reserveAmmo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.itemweaponsetammo, clipAmmo, reserveAmmo);
            //Utils.FuncCaller.ScriptStack.Clear();
        }
        public static void ItemWeaponSetAmmo(this Entity entity, int clipAmmo, int reserveAmmo, int altWeapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.itemweaponsetammo, clipAmmo, reserveAmmo, altWeapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Fire a 'magic bullet', from the source location towards the destination
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Entity MagicBullet(string weapon, Vector3 start, Vector3 end, Entity owner = null)
        {
            //Function.SetEntRef(entity.EntRef);
            if (owner != null) Function.Call(ScriptNames.FunctionList.magicbullet, weapon, start, end, owner);
            else Function.Call(ScriptNames.FunctionList.magicbullet, weapon, start, end);
            //Utils.FuncCaller.ScriptStack.Clear();

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the name of the weapon this weapon has for its alternate mode. Subsequent alternate weapons can be retrieved by calling the function again with the new weapon names until it returns the original weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the name of the weapon this weapon has for its alternate mode. Returns "none" if there is no alt fire</returns>
        public static string WeaponAltWeaponName(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponaltweaponname, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the class of weapon that this weapon is, such as 'rifle', 'smg', 'spread', 'pistol', etc.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the class of weapon that the weapon is</returns>
        public static string WeaponClass(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponclass, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the weapon clip size for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the weapon clip size of the given weapon</returns>
        public static int WeaponClipSize(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponclipsize, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get the weapon fire time for the given weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the weapon fire time for the given weapon</returns>
        public static float WeaponFireTime(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponfiretime, weapon);

            float ret = (float)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the way this weapon is stored, such as 'altmode', 'item', 'offhand', or 'primary'
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the way this weapon is stored</returns>
        public static string WeaponInventoryType(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponinventorytype, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get whether this weapon has a bolt action
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon has a bolt action</returns>
        public static bool WeaponIsBoltAction(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponisboltaction, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Get whether this weapon is semi automatic
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon is semi automatic</returns>
        public static bool WeaponIsSemiAutomatic(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponissemiauto, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets the max amount of ammo this weapon is meant to hold. Stockpile only, not the clip
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the max amount of ammo this weapon is meant to hold</returns>
        public static int WeaponMaxAmmo(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponmaxammo, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the amount of ammo this weapon is meant to start with when first given to a player
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the amount of ammo this weapon is meant to start with when first given to a player</returns>
        public static int WeaponStartAmmo(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponstartammo, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Gets the type of weapon that this weapon is, such as 'bullet', 'projectile', or 'grenade'
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the type of weapon that this weapon is</returns>
        public static string WeaponType(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weapontype, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static void KC_RegWeaponForFxRemoval(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.regweaponforfxremoval, weapon);
            //Utils.FuncCaller.ScriptStack.Clear();
        }

        /// <summary>
        /// Get the hide tags of the weapon model used for the given weapon(TBD)
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the names of the hide tags of the weapon model used for the given weapon</returns>
        public static Array GetWeaponHideTags(string weapon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get whether this weapon is fully automatic
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon is fully automatic</returns>
        public static bool WeaponIsAuto(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponisauto, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Get whether this weapon inherits a perk(TBD)
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon has a perk</returns>
        public static bool WeaponInheritsPerks(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponinheritsperks, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Gets the burst count of a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the burst count of the weapon</returns>
        public static int WeaponBurstCount(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponburstcount, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }

        /// <summary>
        /// Get whether this weapon has a thermal scope
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns true if the weapon has a thermal scope</returns>
        public static bool WeaponHasThermalScope(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponhasthermalscope, weapon);

            int ret = Convert.ToInt32(Function.GetReturns());
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret != 0;
        }

        /// <summary>
        /// Get the name of the weapon's flash tag
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>Returns the name of the weapon's flash tag</returns>
        public static string GetWeaponFlashTag(string weapon)
        {
            //Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponflashtagname, weapon);

            string ret = (string)Function.GetReturns();
            //Utils.FuncCaller.ScriptStack.Clear();
            return ret;
        }
        #endregion
        #region vehicle
        /// <summary>
        /// Attaches this vehicle to the given path
        /// </summary>
        /// <param name="node"></param>
        public static void AttachPath(this Entity vehicle, Entity node)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.attachpath, node);
        }

        /// <summary>
        /// Clear the goal yaw for this direction
        /// </summary>
        public static void ClearGoalYaw(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.cleargoalyaw);
        }

        /// <summary>
        /// Clear the entity the vehicle is orienting towards
        /// </summary>
        public static void ClearLookAtEnt(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.clearlookatent);
        }

        /// <summary>
        /// Clear the target yaw direction for this vehicle
        /// </summary>
        public static void ClearTargetYaw(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetyaw);
        }

        /// <summary>
        /// Clear the target for the vehicle turret
        /// </summary>
        public static void ClearTurretTarget(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.clearturrettarget);
        }

        /// <summary>
        /// Fire the vehicle's weapon
        /// </summary>
        /// <param name="barrelTag"></param>
        /// <param name="targetEnt"></param>
        /// <param name="targetOffset"></param>
        public static void FireWeapon(this Entity vehicle, string barrelTag = "", Entity targetEnt = null, Vector3? targetOffset = null)
        {
            Function.SetEntRef(vehicle.EntRef);
            if (barrelTag == "" && targetEnt == null && targetOffset == null) Function.Call(ScriptNames.FunctionList.fireweapon);
            else if (barrelTag != "" && targetEnt == null) Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag);
            else if (barrelTag != "" && targetEnt != null && targetOffset == null) Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag, targetEnt);
            else Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag, targetEnt, targetOffset);
        }

        /// <summary>
        /// Frees this vehicle instance
        /// </summary>
        public static void FreeVehicle(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.freevehicle);
        }

        /// <summary>
        /// Gets the origin and angles if the vehicle were to be attached to the path. The origin and angles are returned as a <see cref="ScriptArray"/> of size 2. Origin is 1st and angles is 2nd.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Returns the origin and angles if the vehicle were to be attached to the path.</returns>
        public static Entity GetAttachPos(this Entity vehicle, Entity node)
        {
            //throw new NotImplementedException();
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachpos, node);

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the goal speed in miles per hour
        /// </summary>
        /// <returns>Returns the goal speed in miles per hour</returns>
        public static float GetGoalSpeedMPH(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getgoalspeedmph);

            float ret = (float)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the current speed in inches per second
        /// </summary>
        /// <returns>Returns the current speed in inches per second</returns>
        public static int GetSpeed(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getspeed);

            int ret = Convert.ToInt32(Function.GetReturns());
            return ret;
        }

        /// <summary>
        /// Gets the owner of this particular vehicle
        /// </summary>
        /// <returns>Returns the owner of this particualr vehicle</returns>
        public static Entity GetVehicleOwner(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getvehicleowner);

            Entity ret = (Entity)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the surface type of the given wheel
        /// </summary>
        /// <param name="wheel"></param>
        /// <returns>Returns the surface type of the given wheel as a <see cref="string"/></returns>
        public static string GetWheelSurface(this Entity vehicle, string wheel)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getwheelsurface, wheel);

            string ret = (string)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Query whether this vehicle's turret is ready for firing
        /// </summary>
        /// <returns>Returns true if this vehicle's turret is ready to fire, false otherwise.</returns>
        public static bool IsTurretReady(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.isturretready);

            int ret = Convert.ToInt32(Function.GetReturns());
            return ret != 0;
        }

        /// <summary>
        /// Jolts this vehicle
        /// </summary>
        /// <param name="joltPosition"></param>
        /// <param name="intensity"></param>
        /// <param name="fraction"></param>
        /// <param name="deceleration"></param>
        public static void JoltBody(this Entity vehicle, Vector3 joltPosition, float intensity, float fraction = 0f, float deceleration = 0f)
        {
            if (fraction > 1f) fraction = 1f;
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.joltbody, joltPosition, intensity, fraction, deceleration);
        }

        /// <summary>
        /// Sets the vehile to resume it's path speed
        /// </summary>
        /// <param name="acceleration"></param>
        public static void ResumeSpeed(this Entity vehicle, float acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.resumespeed, acceleration);
        }

        /// <summary>
        /// Sets the acceleration for this vehicle
        /// </summary>
        /// <param name="acceleration"></param>
        public static void SetAcceleration(this Entity vehicle, float acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setacceleration, acceleration);
        }

        /// <summary>
        /// Sets the speed at which air resistance maxes out
        /// </summary>
        /// <param name="maxResistanceSpeed"></param>
        public static void SetAirResistance(this Entity vehicle, float maxResistanceSpeed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setairresistance, maxResistanceSpeed);
        }

        /// <summary>
        /// Sets the deceleration for this vehicle
        /// </summary>
        /// <param name="deceleration"></param>
        public static void SetDeceleration(this Entity vehicle, float deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setdeceleration, deceleration);
        }

        /// <summary>
        /// Set the goal yaw direction for this vehicle.Goal yaw is ignored if vehicle doesn't stop at goal. Lookat entity has priority over goal yaw
        /// </summary>
        /// <param name="yaw"></param>
        public static void SetGoalYaw(this Entity vehicle, float yaw)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setgoalyaw, yaw);
        }

        /// <summary>
        /// Set the hovering parameters
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="speed"></param>
        /// <param name="accel"></param>
        public static void SetHoverParams(this Entity vehicle, int radius, float speed, float accel)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.sethoverparams, radius, speed, accel);
        }

        /// <summary>
        /// Set the jitter parameters. Set everything to 0 to stop jittering. Vehicle ignores jitter parameters when on ground
        /// </summary>
        /// <param name="range"></param>
        /// <param name="minPeriod"></param>
        /// <param name="maxPeriod"></param>
        public static void SetJitterParams(this Entity vehicle, Vector3 range, float minPeriod, float maxPeriod)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setjitterparams, range, minPeriod, maxPeriod);
        }

        /// <summary>
        /// Set the entity this vehicle will orient towards
        /// </summary>
        /// <param name="entity"></param>
        public static void SetLookAtEnt(this Entity vehicle, Entity entity)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setlookatent, entity);
        }

        /// <summary>
        /// Sets max pitch and roll angle for this vehicle.
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="roll"></param>
        public static void SetMaxPitchRoll(this Entity vehicle, float pitch, float roll)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setmaxpitchroll, pitch, roll);
        }

        /// <summary>
        /// Set distance near goal at which near_goal notification should be sent once.
        /// </summary>
        /// <param name="dist"></param>
        public static void SetNearGoalNotifyDist(this Entity vehicle, float dist)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setneargoalnotifydist, dist);
        }

        /// <summary>
        /// Sets the speed and acceleration for this vehicle.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        /// <param name="deceleration"></param>
        public static void SetSpeed(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed,speed);
        }
        public static void SetSpeed(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed, speed, acceleration);
        }
        public static void SetSpeed(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed, speed, acceleration, deceleration);
        }

        /// <summary>
        /// Sets the speed and acceleration for this vehicle instantaneously. Direction will be toward the goal direction if there is a goal, otherwise the current direction.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        /// <param name="deceleration"></param>
        public static void SetSpeedImmediate(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed);
        }
        public static void SetSpeedImmediate(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed, acceleration);
        }
        public static void SetSpeedImmediate(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed, acceleration, deceleration);
        }

        /// <summary>
        /// Sets a switch node for this vehicle
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="destNode"></param>
        public static void SetSwitchNode(this Entity vehicle, Entity sourceNode, Entity destNode)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setswitchnode, sourceNode, destNode);
        }

        /// <summary>
        /// Set the target yaw direction for this vehicle. Goal yaw has priority over target yaw.
        /// </summary>
        /// <param name="yaw"></param>
        public static void SetTargetYaw(this Entity vehicle, float yaw)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetyaw, yaw);
        }

        /// <summary>
        /// If this is higher, helicopters can make sharper turns to match goal positions better.
        /// </summary>
        /// <param name="ability"></param>
        public static void SetTurningAbility(this Entity vehicle, float ability)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setturningability, ability);
        }

        /// <summary>
        /// Set the target entity for this vehicle turret.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        public static void SetTurretTargetEnt(this Entity vehicle, Entity target, Vector3? offset = null)
        {
            Function.SetEntRef(vehicle.EntRef);
            if (offset != null) Function.Call(ScriptNames.FunctionList.setturrettargetent, target, offset);
            else Function.Call(ScriptNames.FunctionList.setturrettargetent, target);
        }

        /// <summary>
        /// Set the target position for this vehicle turret.
        /// </summary>
        /// <param name="target"></param>
        public static void SetTurretTargetVec(this Entity vehicle, Vector3 target)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setturrettargetvec, target);
        }

        /// <summary>
        /// Set the target position for this vehicle
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="stopAtGoal"></param>
        public static void SetVehGoalPos(this Entity vehicle, Vector3 goal, bool stopAtGoal)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehgoalpos, goal, stopAtGoal);
        }

        /// <summary>
        /// Set look at text for the vehicle
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        public static void SetVehicleLookAtText(this Entity vehicle, string text1, string text2 = "")
        {
            Function.SetEntRef(vehicle.EntRef);
            if (text2 != "") Function.Call(ScriptNames.FunctionList.setvehiclelookattext, text1, text2);
            else Function.Call(ScriptNames.FunctionList.setvehiclelookattext, text1);
        }

        /// <summary>
        /// Set which team a vehicle is on
        /// </summary>
        /// <param name="team"></param>
        public static void SetVehicleTeam(this Entity vehicle, string team)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehicleteam, team);
        }

        /// <summary>
        /// Set the vehicle's weapon
        /// </summary>
        /// <param name="weapon"></param>
        public static void SetVehWeapon(this Entity vehicle, string weapon)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehweapon, weapon);
        }

        /// <summary>
        /// Sets a the wait speed for for this vehicle in miles per hour.
        /// </summary>
        /// <param name="speed"></param>
        public static void SetWaitSpeed(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaitspeed, speed);
        }

        /// <summary>
        /// Sets the yaw speed for this vehicle
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        /// <param name="deceleration"></param>
        /// <param name="overshootPercent"></param>
        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration);
        }
        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration, deceleration);
        }
        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration, int deceleration, float overshootPercent)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration, deceleration, overshootPercent);
        }

        /// <summary>
        /// Sets the yaw speed for this vehicle using a name. Possible names are 'instant', 'faster', 'fast', and 'slow'
        /// </summary>
        /// <param name="name"></param>
        public static void SetYawSpeedByName(this Entity vehicle, string name)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeedbyname, name);
        }

        /// <summary>
        /// Starts the vehicle following this path
        /// </summary>
        /// <param name="nodeIndex"></param>
        public static void StartPath(this Entity vehicle, Entity node)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.startpath, node);
        }

        /// <summary>
        /// Set a helicopter's AI(TBD)
        /// </summary>
        public static void HeliSetAI(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.helisetai);
        }

        /// <summary>
        /// Checks whether a vehicle's turret can target a point
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Returns true if this vehicle's turret can get the point, false otherwise.</returns>
        public static bool CanTurretGetTargetPoint(this Entity vehicle, Vector3 target)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.canturretgettargetpoint, target);

            int ret = Convert.ToInt32(Function.GetReturns());
            return ret != 0;
        }

        /// <summary>
        /// Sets a player to control a vehicle's turret
        /// </summary>
        /// <param name="player"></param>
        public static void VehicleTurretControlOn(this Entity vehicle, Entity player)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicleturretcontrolon, player);
        }

        /// <summary>
        /// Sets a player to stop controlling a vehicle's turret
        /// </summary>
        /// <param name="player"></param>
        public static void VehicleTurretControlOff(this Entity vehicle, Entity player)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicleturretcontroloff, player);
        }

        /// <summary>
        /// Teleports a vehicle to a location
        /// </summary>
        /// <param name="pos"></param>
        public static void Vehicle_Teleport(this Entity vehicle, Vector3 pos)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_teleport, pos);
        }

        /// <summary>
        /// Gets the current position of the vehicle on it's attach path(TBD)
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetAttachPos(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachpos);

            Vector3 ret = (Vector3)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Invokes damage on a vehicle
        /// </summary>
        /// <param name="inflictor"></param>
        /// <param name="attacker"></param>
        /// <param name="damage"></param>
        /// <param name="damageFlags"></param>
        /// <param name="meansOfDeath"></param>
        /// <param name="weapon"></param>
        /// <param name="point"></param>
        /// <param name="dir"></param>
        /// <param name="hitLoc"></param>
        /// <param name="timeOffset"></param>
        /// <param name="modelIndex"></param>
        /// <param name="partName"></param>
        public static void Vehicle_FinishDamage(this Entity vehicle, Entity inflictor, Entity attacker, int damage, int damageFlags, string meansOfDeath, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_finishdamage, inflictor, attacker, damage, damageFlags, meansOfDeath, weapon, point, dir, hitLoc, timeOffset, modelIndex, partName);
        }

        /// <summary>
        /// Rotates the yaw of a vehicle
        /// </summary>
        /// <param name="yaw"></param>
        /// <param name="time"></param>
        /// <param name="acceleration"></param>
        /// <param name="deceleration"></param>
        public static void RotateYaw(this Entity vehicle, int yaw, int time, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, acceleration, deceleration);
        }

        /// <summary>
        /// Gets the current velocity of a vehicle
        /// </summary>
        /// <returns>Returns the current velocity of the vehicle as a <see cref="Vector3"/></returns>
        public static Vector3 Vehicle_GetVelocity(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_getvelocity);

            Vector3 ret = (Vector3)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the current velocity of a vehicle's body
        /// </summary>
        /// <returns>Returns the current velocity of this vehicle's body as a <see cref="Vector3"/></returns>
        public static Vector3 GetBodyVelocity(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getbodyvelocity);

            Vector3 ret = (Vector3)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the current steering fraction of a vehicle
        /// </summary>
        /// <returns>Returns the current steering fraction of this vehicle as a <see cref="float"/></returns>
        public static float GetSteering(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getsteering);

            float ret = (float)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Gets the current throttle value of a vehicle
        /// </summary>
        /// <returns>Returns the current throttle value of this vehicle as a <see cref="float"/></returns>
        public static float GetThrottle(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getthrottle);

            float ret = (float)Function.GetReturns();
            return ret;
        }

        /// <summary>
        /// Turns the engine off in a vehicle
        /// </summary>
        public static void TurnEngineOff(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.turnengineoff);
        }

        /// <summary>
        /// Turns the engine on in a vehicle
        /// </summary>
        public static void TurnEngineOn(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.turnengineon);
        }

        /// <summary>
        /// Initiates a vehicle to drive to a specified location at a specified speed
        /// </summary>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public static void DriveTo(this Entity vehicle, Vector3 position, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicledriveto, position, speed);
        }

        /// <summary>
        /// Spawns an actor from an actor spawner, if possible
        /// </summary>
        /// <param name="type"></param>
        public static void DoSpawn(this Entity vehicle, string targetName)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.dospawn, targetName);
        }

        /// <summary>
        /// Checks if a vehicle is a physics-based vehicle
        /// </summary>
        /// <returns>Returns true if the given vehicle is a physics-based vehicle, false otherwise.</returns>
        public static bool IsPhysVeh(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.isphysveh);

            int ret = Convert.ToInt32(Function.GetReturns());
            return ret != 0;
        }

        /// <summary>
        /// Crashes a physics-based vehicle
        /// </summary>
        public static void Phys_Crash(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_crash);
        }

        /// <summary>
        /// Launches a physics-based vehicle
        /// </summary>
        public static void Phys_Launch(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_launch);
        }

        /// <summary>
        /// Disables crashing for a physics-based vehicle
        /// </summary>
        public static void Phys_DisableCrashing(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_disablecrashing);
        }

        /// <summary>
        /// Enables crashing for a physics-based vehicle
        /// </summary>
        public static void Phys_EnableCrashing(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_enablecrashing);
        }

        /// <summary>
        /// Sets the speed of a physics-based vehicle
        /// </summary>
        public static void Phys_SetSpeed(this Entity vehicle, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_setspeed, speed);
        }

        /// <summary>
        /// Sets the conveyer belt speed of a physics-based vehicle(TBD)
        /// </summary>
        public static void Phys_SetConveyerBelt(this Entity vehicle, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_setconveyerbelt, speed);
        }

        /// <summary>
        /// Frees this helicopter instance
        /// </summary>
        public static void FreeHelicopter(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.freehelicopter);
        }
        #endregion
    }
}
