import React from "react";
import { useTranslation } from "react-i18next";
import { Header, Menu } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default function BarnFilters() {
  const { t } = useTranslation();
  const { barnStore } = useStore();
  const { predicate, setPredicate } = barnStore;
  return (
    <>
      <Menu vertical size="large" style={{ width: "100%", marginTop: 25 }}>
        <Header
          icon="filter"
          attached
          color="teal"
          content={t("barnFilters.filtersTitle")}
        />
        <Menu.Item
          content={t("barnFilters.filtersAll")}
          active={predicate.has("all")}
          onClick={() => setPredicate("all", true)}
        />
        <Menu.Item
          content={t("barnFilters.filtersActive")}
          active={predicate.has("isActive")}
          onClick={() => setPredicate("isActive", true)}
        />
        <Menu.Item
          content={t("barnFilters.filtersNotActive")}
          active={predicate.has("isInactive")}
          onClick={() => setPredicate("isInactive", true)}
        />
      </Menu>
      <Header />
    </>
  );
}
