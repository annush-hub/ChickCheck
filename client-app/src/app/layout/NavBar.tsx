import { Button, Container, Menu } from "semantic-ui-react";
import { NavLink } from "react-router-dom";
import i18n from "../../i18n";
import { changeLanguage } from "i18next";
import { useTranslation } from "react-i18next";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";

export default observer(function NavBar() {
  const { t } = useTranslation();
  const {
    userStore: { user, logout },
  } = useStore();
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item as={NavLink} to="/" header>
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "10px" }}
          />
          Chick Check
        </Menu.Item>
        <Menu.Item as={NavLink} to="/barns" name={t("navBar.barns")!} />
        <Menu.Item as={NavLink} to="/storages" name={t("navBar.storages")!} />

        <Menu.Item>
          <Button
            as={NavLink}
            to="/createBarn"
            positive
            content={t("navBar.createBarn")}
          />
        </Menu.Item>
        <Menu.Item position="right">
          <Button.Group size="mini">
            <Button
              active={i18n.language === "en"}
              onClick={() => changeLanguage("en")}
            >
              <i className="flag-icon flag-icon-gb"></i>
            </Button>
            <Button.Or />
            <Button
              active={i18n.language === "ua"}
              onClick={() => changeLanguage("ua")}
            >
              <i className="flag-icon flag-icon-ua"></i>
            </Button>
          </Button.Group>
        </Menu.Item>
        <Menu.Item>
          <Button content={t("navBar.logout")!} onClick={logout} icon="power" />
        </Menu.Item>
      </Container>
    </Menu>
  );
});
