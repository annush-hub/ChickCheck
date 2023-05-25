import React from "react";
import { useTranslation } from "react-i18next";
import { Header, Menu } from "semantic-ui-react";

export default function BarnFilters() {
  const { t } = useTranslation();
  return (
    <>
      <Menu vertical size="large" style={{ width: "100%", marginTop: 25 }}>
        <Header
          icon="filter"
          attached
          color="teal"
          content={t("barnFilters.filtersTitle")}
        />
        <Menu.Item content={t("barnFilters.filtersAll")} />
        <Menu.Item content={t("barnFilters.filtersActive")} />
        <Menu.Item content={t("barnFilters.filtersNotActive")} />
      </Menu>
      <Header />
    </>
  );
}
