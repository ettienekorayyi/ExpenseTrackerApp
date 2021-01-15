import React from "react";
import { PieChart } from "react-minimal-pie-chart";
import {
  Segment,
  Header as SemantiUiHeader,
  Header,
  Item,
  Icon,
  Card,
  Grid,
  Container,
} from "semantic-ui-react";

const groceryMock = [
  {
    title: "Groceries",
    value: 200,
    color: "#FAE2D2",
  },
  {
    title: "Budget",
    value: 300,
    color: "#F58234",
  },
];

const CategoryChart = (props) => {
  return (
    <PieChart
      className="donut-chart"
      data={props.dataMock}
      lineWidth={39}
      rounded
      lengthAngle={-360}
      animate
    />
  );
};

export default CategoryChart;
