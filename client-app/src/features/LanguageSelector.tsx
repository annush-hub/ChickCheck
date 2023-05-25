import React from "react";
import { useTranslation } from "react-i18next";
import { Button } from "semantic-ui-react";

function LanguageSelector() {
  const { i18n } = useTranslation();

  const changeLanguage = (language: string) => {
    i18n.changeLanguage(language);
  };

  return (
    <Button.Group>
      <Button onClick={() => changeLanguage("en")}>English</Button>
      <Button onClick={() => changeLanguage("ua")}>Українська</Button>
    </Button.Group>
  );
}

export default LanguageSelector;
