import React, { useEffect } from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Divider,
  Item,
  Icon,
  Grid,
  Container,
} from "semantic-ui-react";
import { connect } from 'react-redux';
import * as actions from '../../../actions';

const paragraph = "lorem ioafjfajnfaj  sa dafn dnfkankfak fdsajk";
const image = "https://react.semantic-ui.com/images/wireframe/square-image.png";

const items = [
  {
    childKey: 0,
    image,
    header: "Header list",
    description:
      "lorem ipsum dolor ipa wjai jdkjaf aw sadfwcafafa fafafs lorem ipsum dolor ipa wjai jdkjaf aw sadfwcafafa fafafs",
    meta: "Metadata",
    extra: (
      <button>
        <Icon className="pencil alternate" />
      </button>
    )
  },
  {
    childKey: 1,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: (
      <button>
        <Icon className="pencil alternate" />
      </button>
    ),
  },
  {
    childKey: 2,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: (
      <button>
        <Icon className="pencil alternate" />
      </button>
    ),
  },
  {
    childKey: 3,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: (
      <button>
        <Icon className="pencil alternate" />
      </button>
    ),
  },
  {
    childKey: 4,
    image,
    header: "Header",
    description: "Description",
    meta: "Metadata",
    extra: (
      <button>
        <Icon className="pencil alternate" />
      </button>
    ),
  },
];

export const ExpensesList = (props) => {
  
  //console.log(props)

  useEffect(() => {
    props.dispatch(actions.addExpense());
    
  }, [])
  return (
    <Item width={10}>
      <Item.Header style={{ margin: 20 }}>
        <Divider horizontal>
          <SemantiUiHeader as="h1">
            <Icon name="calculator" />
            Transactions
          </SemantiUiHeader>
        </Divider>
      </Item.Header>
      <Item.Content>
        <Item.Group id="expense-items" items={items} />
      </Item.Content>
    </Item>
  );
};

//import the connect component from the redux library
// create mapStateToProps
// console log the props

function mapStateToProps(state) {
  return {
    expenses: state.expenses
  }
}

export default connect(mapStateToProps)(ExpensesList);
