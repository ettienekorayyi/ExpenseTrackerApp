import React, { useState } from "react";
import { Menu, Image, Segment, Grid } from "semantic-ui-react";


const Header = () => {
  const [activeItem, setActiveItem] = useState("home");
  const handleItemClick = (e, { name }) => setActiveItem(name);
  

  return (
    <Segment.Group style={{ backgroundColor: "#FFFFFF", border: 0 }}>
      <Menu inverted pointing vertical style={{ minHeight: 450, height: 807 }}>
        <Menu.Item>
          <Image
            src="https://react.semantic-ui.com/images/wireframe/square-image.png"
            size="medium"
            circular
            centered
          />
        </Menu.Item>
        <Menu.Item
          name="home"
          active={activeItem === "home"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="categories"
          active={activeItem === "categories"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="transactions"
          active={activeItem === "transactions"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="withdraw"
          active={activeItem === "withdraw"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="bills"
          active={activeItem === "bills"}
          onClick={handleItemClick}
        />
        <Menu.Item
          name="Settings"
          active={activeItem === "settings"}
          onClick={handleItemClick}
        />
      </Menu>
    </Segment.Group>
  );
};

export default Header;
