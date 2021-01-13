import React from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Grid,
  Item,
} from "semantic-ui-react";

const paragraph = "lorem ioafjfajnfaj  sa dafn dnfkankfak fdsajk";
const image = "https://react.semantic-ui.com/images/wireframe/square-image.png";

const items = [
  {
    childKey: 0,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: "Extra",
  },
  {
    childKey: 1,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: "Extra",
  },
  {
    childKey: 2,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: "Extra",
  },
  {
    childKey: 3,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: "Extra",
  },
  {
    childKey: 4,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: "Extra",
  }
];

const ExpensesList = () => {
  return (
    <Segment.Group basic>
      <SemantiUiHeader as="h1">Expenses</SemantiUiHeader>
      <Item.Group items={items} />
    </Segment.Group>
  );
};

export default ExpensesList;
