import { Button, Container, Menu } from "semantic-ui-react";
import { NavLink } from "react-router-dom";
import i18n from "../../i18n";
import { changeLanguage } from "i18next";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faFlag } from "@fortawesome/free-solid-svg-icons";
import { useTranslation } from "react-i18next";

export default function NavBar() {
  const { t } = useTranslation();

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
        <Menu.Item as={NavLink} to="/errors" name="Errors" />
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
              EN
              {/* <i className="flag flag-us"></i> */}
            </Button>
            <Button.Or />
            <Button
              active={i18n.language === "ua"}
              onClick={() => changeLanguage("ua")}
            >
              UA
              {/* <i className="flag flag-ukraine"></i> */}
            </Button>
          </Button.Group>
        </Menu.Item>
      </Container>
    </Menu>
  );
}
