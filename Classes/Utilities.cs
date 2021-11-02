using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace InfinityScript
{
    public enum ServerCommand
    {
        selectWeapon = 97,
        parseScores = 98,
        announcement = 99,
        configStringModified = 100,
        iPrintLn = 101,
        iPrintLn2 = 102,
        iPrintLnBold = 103,
        chatMessage = 84,
        teamChatMessage = 85,
        unknown = 86,
        stopLocalSound = 87,
        blur = 88,
        clearBlur = 89,
        mapRestart = 90,
        openScriptMenu = 111,
        closeScriptMenu = 112,
        setDvars = 113,
        kickPlayer = 114,
        openMenu = 115,
        closeMenu = 116,
        showHudSplash = 117

    }
    public static class Utilities
    {
        public static string GetWeaponClass(string weapon)
        {
            Function.SetEntRef(-1);

            var tokens = weapon.Split('_');
            var weaponClass = "";

            if (tokens[0] == "iw5")
            {
                var concatName = tokens[0] + "_" + tokens[1];
                weaponClass = GSCFunctions.TableLookup("mp/statstable.csv", 4, concatName, 2);
            }
            else if (tokens[0] == "alt")
            {
                var concatName = tokens[1] + "_" + tokens[2];
                weaponClass = GSCFunctions.TableLookup("mp/statstable.csv", 4, concatName, 2);
            }
            else
            {
                weaponClass = GSCFunctions.TableLookup("mp/statstable.csv", 4, tokens[0], 2);
            }

            if (weaponClass == "")
            {
                weapon = Regex.Replace(weapon, "_mp$", "");

                weaponClass = GSCFunctions.TableLookup("mp/statstable.csv", 4, weapon, 2);
            }

            if (weapon == "none" || weaponClass == "")
            {
                weaponClass = "other";
            }

            return weaponClass;
        }

        public static string GetAttachmentType(string attachmentName)
        {
            Function.SetEntRef(-1);
            return GSCFunctions.TableLookup("mp/attachmenttable.csv", 4, attachmentName, 2);
        }

        public static string AttachmentMap(string attachmentName, string weaponName)
        {
            Function.SetEntRef(-1);

            var weaponClass = GSCFunctions.TableLookup("mp/statstable.csv", 4, weaponName, 2);

            switch (weaponClass)
            {
                case "weapon_smg":
                    if (attachmentName == "reflex")
                        return "reflexsmg";
                    else if (attachmentName == "eotech")
                        return "eotechsmg";
                    else if (attachmentName == "acog")
                        return "acogsmg";
                    else if (attachmentName == "thermal")
                        return "thermalsmg";

                    return attachmentName;
                case "weapon_lmg":
                    if (attachmentName == "reflex")
                        return "reflexlmg";
                    else if (attachmentName == "eotech")
                        return "eotechlmg";

                    return attachmentName;
                case "weapon_machine_pistol":
                    if (attachmentName == "reflex")
                        return "reflexsmg";
                    else if (attachmentName == "eotech")
                        return "eotechsmg";

                    return attachmentName;
                default:
                    return attachmentName;
            }
        }

        public static string BuildWeaponName(string baseName, string attachment1, string attachment2, int camo, int reticle)
        {
            Function.SetEntRef(-1);

            if (attachment1 == null)
            {
                attachment1 = "none";
            }

            if (attachment2 == null)
            {
                attachment2 = "none";
            }

            if (reticle > 0 && GetAttachmentType(attachment1) != "rail" && GetAttachmentType(attachment2) != "rail")
            {
                reticle = 0;
            }

            if (GetAttachmentType(attachment1) == "rail")
            {
                attachment1 = AttachmentMap(attachment1, baseName);
            }
            else if (GetAttachmentType(attachment2) == "rail")
            {
                attachment2 = AttachmentMap(attachment2, baseName);
            }

            var bareWeaponName = "";
            var weaponName = "";

            if (baseName.Contains("iw5_"))
            {
                weaponName = baseName + "_mp";
                bareWeaponName = baseName.Substring(4);
            }
            else
            {
                weaponName = baseName;
            }

            string[] attachments = new string[3];

            if (attachment1 != "none" && attachment2 != "none")
            {
                if (attachment1.CompareTo(attachment2) <= 0)
                {
                    attachments[0] = attachment1;
                    attachments[1] = attachment2;
                }
                else
                {
                    attachments[0] = attachment2;
                    attachments[1] = attachment1;
                }

                if (GetWeaponClass(baseName) == "weapon_sniper" && GetAttachmentType(attachment1) != "rail" && GetAttachmentType(attachment2) != "rail")
                {
                    if (attachment1 != "zoomscope" && attachment2 != "zoomscope")
                    {
                        attachments[2] = bareWeaponName + "scope";
                    }
                }
            }
            else if (attachment1 != "none")
            {
                attachments[0] = attachment1;

                if (GetWeaponClass(baseName) == "weapon_sniper" && GetAttachmentType(attachment1) != "rail" && attachment1 != "zoomscope")
                {
                    attachments[1] = bareWeaponName + "scope";
                }
            }
            else if (attachment2 != "none")
            {
                attachments[0] = attachment2;

                if (GetWeaponClass(baseName) == "weapon_sniper" && GetAttachmentType(attachment2) != "rail" && attachment2 != "zoomscope")
                {
                    attachments[1] = bareWeaponName + "scope";
                }
            }
            else if (GetWeaponClass(baseName) == "weapon_sniper")
            {
                attachments[0] = bareWeaponName + "scope";
            }

            if (attachments[0] != null && attachments[0] == "vzscope")
            {
                attachments[0] = bareWeaponName + "scopevz";
            }
            else if (attachments[1] != null && attachments[1] == "vzscope")
            {
                attachments[1] = bareWeaponName + "scopevz";
            }
            else if (attachments[2] != null && attachments[2] == "vzscope")
            {
                attachments[2] = bareWeaponName + "scopevz";
            }

            attachments = attachments.OrderBy(attachment => attachment ?? "zz").ToArray();

            foreach (var attachment in attachments)
            {
                if (string.IsNullOrEmpty(attachment))
                {
                    continue;
                }

                weaponName += "_" + attachment;
            }

            var weaponClass = GetWeaponClass(baseName);

            if (weaponName.Contains("iw5_"))
            {
                if (weaponClass != "weapon_pistol" && weaponClass != "weapon_machine_pistol" && weaponClass != "weapon_projectile")
                {
                    weaponName = BuildWeaponNameCamo(weaponName, camo);
                }

                weaponName = BuildWeaponNameReticle(weaponName, reticle);

                return weaponName;
            }
            else
            {
                if (weaponClass != "weapon_pistol" && weaponClass != "weapon_machine_pistol" && weaponClass != "weapon_projectile")
                {
                    weaponName = BuildWeaponNameCamo(weaponName, camo);
                }

                weaponName = BuildWeaponNameReticle(weaponName, reticle);

                return weaponName + "_mp";
            }
        }

        private static string BuildWeaponNameCamo(string weaponName, int camo)
        {
            if (camo <= 0)
            {
                return weaponName;
            }

            if (camo < 10)
            {
                weaponName += "_camo0";
            }
            else
            {
                weaponName += "_camo";
            }

            weaponName += camo.ToString();

            return weaponName;
        }

        private static string BuildWeaponNameReticle(string weaponName, int reticle)
        {
            if (reticle <= 0)
            {
                return weaponName;
            }

            return weaponName + "_scope" + reticle.ToString();
        }

        public static unsafe void SetDropItemEnabled(bool enabled)
        {
            //GameInterface.SetDropItemEnabled(enabled);
            if (enabled) *(short*)0x47D53B = 0x0B75;
            else { *(byte*)0x47D53B = 0x90; *(byte*)0x47D53C = 0x90; }
        }
        internal static unsafe void setPlayerName(int entRef, string name)
        {
            if (entRef > 17 || !Entity.GetEntity(entRef).IsPlayer)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set name {0} for entity {1} because the entity is not a player.", name, entRef));
                return;
            }
            if (name.Length > 15)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set name {0} for entity {1} because the name is over 15 characters.", name, entRef));
                return;
            }
            IntPtr name_static = new IntPtr(0x1AC5490);
            IntPtr name_realtime = new IntPtr(0x1AC5508);
            int offset = 0x38A4;
            byte[] nameString = Encoding.ASCII.GetBytes(name);
            if (name.Length < 15)
            {
                byte[] nameArray = new byte[nameString.Length + 1];
                nameString.CopyTo(nameArray, 0);
                nameArray[nameString.Length] = 0x0;

                Marshal.Copy(nameArray, 0, name_static + (offset * entRef), nameArray.Length);
                Marshal.Copy(nameArray, 0, name_realtime + (offset * entRef), nameArray.Length);
            }
            else
            {
                Marshal.Copy(nameString, 0, name_static + (offset * entRef), name.Length);
                Marshal.Copy(nameString, 0, name_realtime + (offset * entRef), name.Length);
            }
        }
        internal static unsafe void setPlayerTitle(int entRef, string title)
        {
            if (entRef > 17 || !Entity.GetEntity(entRef).IsPlayer)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set title {0} for entity {1} because the entity is not a player.", title, entRef));
                return;
            }
            if (title.Length > 31)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set title {0} for entity {1} because the name is over 31 characters.", title, entRef));
                return;
            }
            IntPtr title_ptr = new IntPtr(0x01AC5548);
            int offset = 0x38A4;
            byte[] titleString = Encoding.ASCII.GetBytes(title);

            byte[] titleArray = new byte[titleString.Length + 1];
            titleString.CopyTo(titleArray, 0);
            titleArray[titleString.Length] = 0x0;

            Marshal.Copy(titleArray, 0, title_ptr + (offset * entRef), titleArray.Length);
        }
        internal static unsafe string getPlayerTitle(int entRef)
        {
            IntPtr title_ptr = new IntPtr(0x01AC5548);
            byte[] titleBytes = new byte[7];
            Marshal.Copy(title_ptr, titleBytes, 0, 7);

            string title = Encoding.ASCII.GetString(titleBytes);

            return title;
        }
        internal static unsafe void setPlayerClanTag(int entRef, string tag)
        {
            if (entRef > 17 || !Entity.GetEntity(entRef).IsPlayer)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set name {0} for entity {1} because the entity is not a player.", tag, entRef));
                return;
            }
            if (tag.Length > 7)
            {
                PrintToConsole(string.Format("[InfinityScript]Error: cannot set name {0} for entity {1} because the name is over 7 characters.", tag, entRef));
                return;
            }
            IntPtr tag_ptr = new IntPtr(0x01AC5564);
            int offset = 0x38A4;
            byte[] tagString = Encoding.ASCII.GetBytes(tag);
            if (tag.Length < 7)
            {
                byte[] tagArray = new byte[tagString.Length + 1];
                tagString.CopyTo(tagArray, 0);
                tagArray[tagString.Length] = 0x0;

                Marshal.Copy(tagArray, 0, tag_ptr + (offset * entRef), tagArray.Length);
            }
            else
            {
                Marshal.Copy(tagString, 0, tag_ptr + (offset * entRef), tag.Length);
            }
        }
        internal static unsafe string getPlayerClanTag(int entRef)
        {
            IntPtr tag_ptr = new IntPtr(0x01AC5564);
            byte[] tagBytes = new byte[7];
            Marshal.Copy(tag_ptr, tagBytes, 0, 7);

            string tag = Encoding.ASCII.GetString(tagBytes);

            return tag;
        }

        public static Entity AddTestClient()
        {
            var entref = GameInterface.AddTestClient();

            if (entref == 0)
            {
                return null;
            }

            return Entity.GetEntity(entref);
        }

        public static void ExecuteCommand(string command)
        {
            GameInterface.Cbuf_AddText(command + "\n");
        }

        public static void ExecuteCommand(string format, params object[] args)
        {
            ExecuteCommand(String.Format(format, args));
        }

        #region say commands
        public static void SayTo(Entity ent, string message)
        {
            SayTo(ent.EntRef, message);
        }
        public static void SayTo(int entref, string message)
        {
            SayTo(entref, "console", message);
        }
        public static void SayTo(Entity ent, string name, string message)
        {
            SayTo(ent.EntRef, name, message);
        }
        public static void SayTo(int entref, string name, string message)
        {
            RawSayTo(entref, name + ": " + message);
        }

        public static void SayAll(string message)
        {
            SayAll("console", message);
        }
        public static void SayAll(string name, string message)
        {
            RawSayAll(name + ": " + message);
        }

        public static void RawSayAll(string message)
        {
            GameInterface.SV_GameSendServerCommand(-1, -1, message);
        }
        public static void RawSayTo(Entity ent, string message)
        {
            RawSayTo(ent.EntRef, message);
        }
        public static void RawSayTo(int entref, string message)
        {
            GameInterface.SV_GameSendServerCommand(entref, -1, message);
        }
        public static void GameSendServerCommand(this Entity ent, int id, string message)
        {
            GameInterface.SV_GameSendServerCommand(ent.EntRef, id, message);
        }
        #endregion

        public static string[] Tokenize(string line)
        {
            GameInterface.Cmd_TokenizeString(line);
            var argc = GameInterface.Cmd_Argc();
            if(argc == 0)
            {
                throw new ArgumentException();
            }
            var tokenized = new string[argc];
            for (int i = 0; i < argc; i++)
            {
                tokenized[i] = GameInterface.Cmd_Argv(i);
            }
            GameInterface.Cmd_EndTokenizedString();
            return tokenized;
        }

        public static bool isEntDefined(Entity ent)
        {
            if (ent == null) return false;
            return GSCFunctions.GetEntByNum(ent.EntRef) != null;
        }

        public static string[] getCurrentlyLoadedScripts()
        {
            List<BaseScript> scripts = ScriptProcessor._scripts;
            string[] scriptNames = new string[scripts.Count];
            for (int i = 0; i < scripts.Count; i++)
            {
                scriptNames[i] = scripts[i].GetType().ToString();
            }
            
            return scriptNames;
        }

        public static void PrintToConsole(string text)
            => GameInterface.Print(text + "\n");
    }
}
