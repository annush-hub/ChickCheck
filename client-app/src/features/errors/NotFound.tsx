import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment } from "semantic-ui-react";

export default function NotFound() {
  return (
    <Segment placeholder>
      <Header icon>
        {" "}
        <Icon name="search" />
        Could't find what you're looking for :\
      </Header>
      <Segment.Inline>
        <Button as={Link} to="/barns" content="Return to Barns page" />
      </Segment.Inline>
    </Segment>
  );
}
