import React from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Divider,
  Item,
  Icon,
  Card,
  Grid,
} from "semantic-ui-react";

const items = [
  {
    key: "sdfaa1",
    header: "Total Expenses",
    description:
      "1200",
    meta: "ROI: 30%",
  },
  {
    key: "sdfaa2",
    header: "Income",
    description:
      "3000",
    meta: "ROI: 30%",
  },
  {
    key: "sdfaa3",
    header: "Remaining",
    description:
      "1200",
    meta: "ROI: 30%",
  },
];

const CurrentExpenses = () => {
  return (
    <Segment.Group basic>
      <Segment>
        <Item width={10}>
          <Item.Header style={{ margin: 20 }}>
            <Divider horizontal>
              <SemantiUiHeader as="h1">
                <Icon name="tag" />
                Summary
              </SemantiUiHeader>
            </Divider>
          </Item.Header>
          <Grid columns={3}>
            {items.map((i) => {
              return (
                <Grid.Column>
                  <Card.Group>
                    <Card>
                      <Card.Content>
                        <Card.Header>{i.header}</Card.Header>
                        <Card.Description>
                          <i class="dollar sign icon" />
                          <strong>{i.description}</strong>
                        </Card.Description>
                      </Card.Content>
                    </Card>
                  </Card.Group>
                </Grid.Column>
              );
            })}
          </Grid>
        </Item>
      </Segment>
    </Segment.Group>
  );
};

export default CurrentExpenses;
