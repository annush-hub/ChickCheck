import React from "react";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import LanguageSelector from "../LanguageSelector";
import { useTranslation } from "react-i18next";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

export default observer(function HomePage() {
  const { userStore } = useStore();
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
            <Button as={Link} to="/login" size="huge" inverted>
              Login
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
