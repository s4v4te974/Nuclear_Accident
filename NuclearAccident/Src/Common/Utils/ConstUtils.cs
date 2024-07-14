namespace NuclearAccident.Src.Common.Utils

{
    public static class ConstUtils
    {

        #region ErrorMessage
        public const string UNABLE_TO_RETRIEVE_ALL_BA = "Unable to retrieve all Broken Arrows";

        public const string UNABLE_TO_RETRIEVE_BA_BY_VEHICULE = "Unable to retrieve broken Arrows by vehicules";

        public const string UNABLE_TO_RETRIEVE_BA_BY_WEAPON = "Unable to retrieve broken Arrows by weapons";

        public const string UNABLE_TO_RETRIEVE_BA_BY_YEAR = "Unable to retrieve broken Arrows by years";

        public const string UNABLE_TO_RETRIEVE_SINGLE_BA = "Unable to retrieve the specified Broken Arrows";

        public const string UNABLE_TO_RETRIEVE_BA_BY_LOCATION = "Unable to retrieve broken Arrows by location";

        public const string UNABLE_TO_RETRIEVE_ALL_LOCATION = "Unable to retrieve all location";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION = "Unable to retrieve specific location";

        public const string UNABLE_TO_RETRIEVE_ALL_VEHICULE = "Unable to retrieve all vehicule";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE = "Unable to retrieve specific vehicule";

        public const string UNABLE_TO_RETRIEVE_ALL_WEAPON = "Unable to retrieve all weapon";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON = "Unable to retrieve specific weapon";

        public const string ERROR_LOG_VEHICULE = "Erreur de base de données dans le service Vehicule";

        public const string ERROR_LOG_WEAPON = "Erreur de base de données dans le service Weapon";

        public const string ERROR_LOG_COORDONATE = "Erreur de base de données dans le service Coordonate";

        public const string ERROR_LOG_BA = "Erreur de base de données dans le service Broken Arrow";

        public const string INVALID_GUID = "Invalid Guid";

        #endregion

        #region apiroute

        public const string ROOT_URL = "broken-arrow/";

        public const string ALL_BROKEN_ARROW = "all/";

        public const string VEHICULE_ROOT_URL = ROOT_URL + "vehicules/";

        public const string VEHICULE_SPECIFIC_URL = "specific-vehicule/{id}";

        public const string LOCATION_ROOT_URL = ROOT_URL + "location/";

        public const string LOCATION_SPECIFIC_URL = "specific-location/{id}";

        public const string WEAPON_ROOT_URL = ROOT_URL + "weapons/";

        public const string WEAPON_SPECIFIC_URL = "specific-weapon/{id}";

        public const string STATS_URL = "stats/";

        #endregion
    }
}
