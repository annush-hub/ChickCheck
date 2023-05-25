import i18n from "i18next";
import { initReactI18next } from "react-i18next";

import translationEN from "./locales/en.json"; // English translations
import translationUA from "./locales/ua.json"; // Ukrainian translations

// Initialize i18next
i18n.use(initReactI18next).init({
  resources: {
    en: {
      translation: translationEN,
    },
    ua: {
      translation: translationUA,
    },
  },
  fallbackLng: "en", // Fallback language
  debug: true, // Enable debug mode
  interpolation: {
    escapeValue: false, // React already escapes the values
  },
});

export default i18n;
