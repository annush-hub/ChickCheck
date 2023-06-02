import React, { Fragment } from "react";
import { useTranslation } from "react-i18next";
import { Button, Item, Label, Placeholder, Segment } from "semantic-ui-react";

export default function BarnListItemPlaceholder() {
  const { t } = useTranslation();
  return (
    <Fragment>
      <Placeholder fluid style={{ marginTop: 25 }}>
        <Segment.Group>
          <Segment style={{ minHeight: 70 }}>
            <Label>
              <Placeholder.Line />
            </Label>
            <Item.Group>
              <Item>
                <Item.Content>
                  <Placeholder>
                    <Placeholder.Header>
                      <Placeholder.Line />
                      <Placeholder.Line />
                    </Placeholder.Header>
                  </Placeholder>
                </Item.Content>
              </Item>
            </Item.Group>
          </Segment>
          <Segment secondary style={{ minHeight: 50 }} />
          <Segment clearing>
            <Button
              disabled
              floated="right"
              content={t("barnList.itemView")}
              color="orange"
            />
          </Segment>
        </Segment.Group>
      </Placeholder>
    </Fragment>
  );
}
