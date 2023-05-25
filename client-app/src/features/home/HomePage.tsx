import React from "react";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import LanguageSelector from "../LanguageSelector";
import { useTranslation } from "react-i18next";

export default function HomePage() {
  const { t } = useTranslation();
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image src="/assets/logo.png" alt="logo" size="massive" />
          ChickCheck
        </Header>
        <Header as="h2" content={t("homePage.welcome")} inverted />
        <Button as={Link} to="/barns" size="huge" inverted>
          Go to Barns
        </Button>
      </Container>
      <Container>
        <LanguageSelector />
      </Container>
    </Segment>
  );
}
