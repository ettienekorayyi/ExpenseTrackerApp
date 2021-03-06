import React from "react";
import {
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
    description: "1200",
    meta: "ROI: 30%",
  },
  {
    key: "sdfaa2",
    header: "Income",
    description: "3000",
    meta: "ROI: 30%",
  },
  {
    key: "sdfaa3",
    header: "Remaining",
    description: "1200",
    meta: "ROI: 30%",
  },
];

const ExpensesSummary = () => {
  return (
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
              <Card>
                <Card.Content>
                  <Card.Header key={i.key}>{i.header}</Card.Header>
                  <Card.Description>
                    <i className="dollar sign icon" />
                    <strong>{i.description}</strong>
                  </Card.Description>
                </Card.Content>
              </Card>
            </Grid.Column>
          );
        })}
      </Grid>
    </Item>
  );
};

export default ExpensesSummary;
