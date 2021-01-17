import React from "react";
import {
  Segment,
  Header as SemantiUiHeader,
  Icon,
  Image,
  Card,
  Divider,
  Item,
} from "semantic-ui-react";

const Categories = () => {
  return (
    <Item>
      <Item.Header style={{ margin: 20 }}>
        <Divider horizontal>
          <SemantiUiHeader as="h1" style={{ color: 'white' }}>
            <Icon name="calculator" />
            Categories
          </SemantiUiHeader>
        </Divider>
      </Item.Header>
      <Item.Group
        style={{ width: "inherit", overflowX: "hidden", height: "55vh" }}
      >
        <Card.Group>
          <Card>
            <Image
              src="https://react.semantic-ui.com/images/avatar/large/daniel.jpg"
              wrapped
              ui={false}
            />
            <Card.Content>
              <Card.Header>Daniel</Card.Header>
              <Card.Meta>Joined in 2016</Card.Meta>
              <Card.Description>
                Daniel is a comedian living in Nashville.
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <a>
                <Icon name="user" />
                10 Friends
              </a>
            </Card.Content>
          </Card>

          <Card>
            <Image
              src="https://react.semantic-ui.com/images/avatar/large/daniel.jpg"
              wrapped
              ui={false}
            />
            <Card.Content>
              <Card.Header>Daniel</Card.Header>
              <Card.Meta>Joined in 2016</Card.Meta>
              <Card.Description>
                Daniel is a comedian living in Nashville.
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <a>
                <Icon name="user" />
                10 Friends
              </a>
            </Card.Content>
          </Card>

          <Card>
            <Image
              src="https://react.semantic-ui.com/images/avatar/large/daniel.jpg"
              wrapped
              ui={false}
            />
            <Card.Content>
              <Card.Header>Daniel</Card.Header>
              <Card.Meta>Joined in 2016</Card.Meta>
              <Card.Description>
                Daniel is a comedian living in Nashville.
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <a>
                <Icon name="user" />
                10 Friends
              </a>
            </Card.Content>
          </Card>

          <Card>
            <Image
              src="https://react.semantic-ui.com/images/avatar/large/daniel.jpg"
              wrapped
              ui={false}
            />
            <Card.Content>
              <Card.Header>Daniel</Card.Header>
              <Card.Meta>Joined in 2016</Card.Meta>
              <Card.Description>
                Daniel is a comedian living in Nashville.
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <a>
                <Icon name="user" />
                10 Friends
              </a>
            </Card.Content>
          </Card>

          <Card>
            <Image
              src="https://react.semantic-ui.com/images/avatar/large/daniel.jpg"
              wrapped
              ui={false}
            />
            <Card.Content>
              <Card.Header>Daniel</Card.Header>
              <Card.Meta>Joined in 2016</Card.Meta>
              <Card.Description>
                Daniel is a comedian living in Nashville.
              </Card.Description>
            </Card.Content>
            <Card.Content extra>
              <a>
                <Icon name="user" />
                10 Friends
              </a>
            </Card.Content>
          </Card>
        </Card.Group>
      </Item.Group>
    </Item>
  );
};

export default Categories;
