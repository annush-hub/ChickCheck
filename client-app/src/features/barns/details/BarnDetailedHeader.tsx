import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Header, Item, Segment, ButtonGroup } from "semantic-ui-react";
import { Barn } from "../../../app/models/barn";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";

interface Props {
  barn: Barn;
}

export default observer(function ActivityDetailedHeader({ barn }: Props) {
  const { t } = useTranslation();
  return (
    <Segment.Group>
      <Segment basic attached="top" style={{ padding: "0" }}>
        <Segment basic>
          <Item.Group>
            <Item>
              <Item.Content>
                <Header size="huge" content={barn.name} />
              </Item.Content>
            </Item>
          </Item.Group>
        </Segment>
      </Segment>
      <Segment clearing attached="bottom">
        <ButtonGroup widths="2">
          <Button
            as={Link}
            to={`/edit/${barn.id}`}
            color="orange"
            content={t("barn.editItem")}
          />
          <Button
            as={Link}
            to={"/barns"}
            color="grey"
            content={t("barn.cancel")}
          />
        </ButtonGroup>
      </Segment>
    </Segment.Group>
  );
});
