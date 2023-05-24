import React from "react";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";

export default function HomePage() {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image src="/assets/logo.png" alt="logo" size="massive" />
          ChickCheck
        </Header>
        <Header as="h2" content="Welcome" inverted />
        <Button as={Link} to="/barns" size="huge" inverted>
          Go to Barns
        </Button>
      </Container>
    </Segment>
    // <Container style={{ marginTop: "7em" }}>
    //   <h1>Home page</h1>
    //   <h3>
    //     {" "}
    //     Go to <Link to="/barns">Barns</Link>
    //   </h3>
    // </Container>
  );
}
