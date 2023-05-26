import React from "react";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import LanguageSelector from "../LanguageSelector";
import { useTranslation } from "react-i18next";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";

export default observer(function HomePage() {
  const { userStore, modalStore } = useStore();
  const { isLoggedIn } = userStore;
  const { t } = useTranslation();
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image src="/assets/logo.png" alt="logo" size="massive" />
          ChickCheck
        </Header>
        {isLoggedIn ? (
          <>
            <Header as="h2" content={t("homePage.welcome")} inverted />
            <Button as={Link} to="/barns" size="huge" inverted>
              {t("homePage.goToBarns")}
            </Button>
          </>
        ) : (
          <>
            <Button
              onClick={() => modalStore.openModal(<LoginForm />)}
              size="huge"
              inverted
            >
              Login
            </Button>
            <Button
              onClick={() => modalStore.openModal(<RegisterForm />)}
              size="huge"
              inverted
            >
              Register
            </Button>
          </>
        )}

        <div style={{ marginTop: 25 }}>
          <LanguageSelector />
        </div>
      </Container>
    </Segment>
  );
});
