import React from "react";
import { Grid, Segment, Item, Image, Container } from "semantic-ui-react";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/dashboard/ExpensesList";
import { styleExpenses } from "../common/styleHelper";

const searchBoxStyle = {
  borderRadius: 0,
};
const Content = () => {
  return (
    <Grid columns={3} >
      <Grid.Column id='navigation-grid'>
        <Header />
      </Grid.Column>
      <Grid.Column id='expenses-grid'>
        <ExpensesList />
      </Grid.Column>
    </Grid>
  );
};

export default Content;
