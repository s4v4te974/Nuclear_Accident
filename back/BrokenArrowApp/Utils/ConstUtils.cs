namespace BrokenArrowApp.Utils
{
    public static class ConstUtils
    {

        #region ErrorMessage
        public const string UNABLE_TO_RETRIEVE_ALL_BA = "Unable to retrieve all Broken Arrows";

        public const string UNABLE_TO_RETRIEVE_BA_BY_VEHICULE = "Unable to retrieve broken Arrows by vehicules";

        public const string UNABLE_TO_RETRIEVE_BA_BY_WEAPON = "Unable to retrieve broken Arrows by weapons";

        public const string UNABLE_TO_RETRIEVE_BA_BY_YEAR = "Unable to retrieve broken Arrows by years";

        public const string UNABLE_TO_RETRIEVE_SINGLE_BA = "Unable to retrieve the specified Broken Arrows";

        public const string UNABLE_TO_RETRIEVE_BA_BY_COORDONATE = "Unable to retrieve broken Arrows by coordonate";

        public const string UNABLE_TO_RETRIEVE_ALL_COORDONATE = "Unable to retrieve all coordonates";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_COORDONATE = "Unable to retrieve specific coordonates";

        public const string UNABLE_TO_RETRIEVE_ALL_VEHICULE = "Unable to retrieve all vehicule";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE = "Unable to retrieve specific vehicule";

        public const string UNABLE_TO_RETRIEVE_ALL_WEAPON = "Unable to retrieve all weapon";

        public const string UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON = "Unable to retrieve specific weapon";

        public const string ERROR_LOG_VEHICULE = "Erreur de base de données dans le service Vehicule";

        public const string ERROR_LOG_WEAPON = "Erreur de base de données dans le service Weapon";

        public const string ERROR_LOG_COORDONATE = "Erreur de base de données dans le service Coordonate";

        public const string ERROR_LOG_BA = "Erreur de base de données dans le service Broken Arrow";

        #endregion

        #region apiroute

        public const string ROOT_URL = "Broken-Arrow/";

        public const string GENERAL_ID = "{id}";

        public const string ALL_VEHICULE_URL = "get-all-vehicule/";

        public const string SPECIFIC_VEHICULE = "get-specific-vehicule/";

        public const string ALL_COORDONATE_URL = "get-all-coordonate/";

        public const string SPECIFIC_COORDONATE = "get-specific-coordonate/";

        public const string ALL_WEAPON_URL = "get-all-weapon/";

        public const string SPECIFIC_WEAPON = "get-specific-weapon/";



        #endregion
    }
}
