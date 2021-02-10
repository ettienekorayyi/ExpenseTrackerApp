import React from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Header,
  Item,
  Icon,
  Divider,
  Grid,
  Container,
} from "semantic-ui-react";
import CategoryChartWidget from "../../categories/CategoryChartWidget";

const items = [
  {
    key: "sdfaa1",
    title: "Food and Beverages",
    value: 1200,
    meta: "ROI: 30%",
    color: "#FAE2D2",
  },
  {
    key: "sdfaa2",
    title: "Groceries",
    value: 300,
    meta: "ROI: 30%",
    color: "#F58234",
  },
  {
    key: "sdfaa3",
    title: "Household",
    value: 1000,
    meta: "ROI: 30%",
    color: "#F58234",
  },
];

const foodAndBeverageMock = [
  { title: "Food & Beverages", value: 120, color: "#FAE2D2" },
  { title: "Budget", value: 150, color: "#F58234" },
];

const groceriesMock = [
  { title: "Groceries", value: 130, color: "#0B69FF" },
  { title: "Budget", value: 120, color: "#B7D3FF" },
];

const householdMock = [
  { title: "Household", value: 170, color: "#0B69FF" },
  { title: "Budget", value: 150, color: "#B7D3FF" },
];

const ExpensesCategory = () => {
  return (
    <Grid className="colored">
      <Header as='h2' style={{ color: '#ffffff'}}>Expenses by Category</Header>
      <Grid.Row className="category-row">
        <Grid.Column width={3}>
          <CategoryChartWidget dataMock={foodAndBeverageMock} />
        </Grid.Column>

        <Grid.Column width={10}>
          <Item.Header>
            <Item.Header>
              <Header as="h2">{items[1].title}</Header>
            </Item.Header>
            <Item.Extra>
              <span>$1200</span>
            </Item.Extra>
          </Item.Header>
        </Grid.Column>

        <Grid.Column width={3}>
          <Item.Header>
            <Header as="h2">%</Header>
          </Item.Header>
        </Grid.Column>
      </Grid.Row>

      <Grid.Row className="category-row">
        <Grid.Column width={3}>
          <CategoryChartWidget dataMock={groceriesMock} />
        </Grid.Column>

        <Grid.Column width={10}>
          <Item.Header>
            <Item.Header>
              <Header as="h2">{items[2].title}</Header>
            </Item.Header>
            <Item.Extra>
              <span>$1200</span>
            </Item.Extra>
          </Item.Header>
        </Grid.Column>

        <Grid.Column width={3}>
          <Item.Header>
            <Header as="h2">%</Header>
          </Item.Header>
        </Grid.Column>
      </Grid.Row>

      <Grid.Row className="category-row">
        <Grid.Column width={3}>
          <CategoryChartWidget dataMock={householdMock} />
        </Grid.Column>

        <Grid.Column width={10}>
          <Item.Header>
            <Item.Header>
              <Header as="h2">{items[0].title}</Header>
            </Item.Header>
            <Item.Extra>
              <span>{items[0].value}</span>
            </Item.Extra>
          </Item.Header>
        </Grid.Column>

        <Grid.Column width={3}>
          <Item.Header>
            <Header as="h2">%</Header>
          </Item.Header>
        </Grid.Column>
      </Grid.Row>
    </Grid>
  );
};

export default ExpensesCategory;
