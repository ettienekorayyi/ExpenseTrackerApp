import React from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Divider,
  Item,
  Icon,
} from "semantic-ui-react";

const paragraph = "lorem ioafjfajnfaj  sa dafn dnfkankfak fdsajk";
const image = "https://react.semantic-ui.com/images/wireframe/square-image.png";

const items = [
  {
    childKey: 0,
    image,
    header: "Header",
    description:
      "lorem ipsum dolor ipa wjai jdkjaf aw sadfwcafafa fafafs lorem ipsum dolor ipa wjai jdkjaf aw sadfwcafafa fafafs",
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
  },
];

const ExpensesList = () => {
  return (
    <Segment.Group basic>
      <Segment>
        <Item width={10}>
          <Item.Header style={{ margin: 20 }}>
            <Divider horizontal>
              <SemantiUiHeader as="h1">
                <Icon name="tag" />
                Transactions
              </SemantiUiHeader>
            </Divider>
          </Item.Header>
          <Item.Group items={items} />
        </Item>
      </Segment>
    </Segment.Group>
  );
};

export default ExpensesList;
