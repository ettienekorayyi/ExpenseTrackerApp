import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Menu, Image } from "semantic-ui-react";
import { headerMenuStyle } from "../../app/common/styleHelper";

const Header = () => {
  const [activeItem, setActiveItem] = useState("home");
  const handleItemClick = (e, { name }) => setActiveItem(name);

  return (
    <Menu inverted pointing vertical style={headerMenuStyle}>
      <Menu.Item>
        <Image
          src="https://react.semantic-ui.com/images/wireframe/square-image.png"
          size="medium"
          circular
          centered
        />
      </Menu.Item>
      <Link to="/">
        <Menu.Item
          name="home"
          active={activeItem === "home"}
          onClick={handleItemClick}
        />
      </Link>
      <Link to="/expenses">
        <Menu.Item
          name="expenses"
          active={activeItem === "expenses"}
          onClick={handleItemClick}
        />
      </Link>
      <Menu.Item
        name="categories"
        active={activeItem === "categories"}
        onClick={handleItemClick}
      />
      <Menu.Item
        name="withdraw"
        active={activeItem === "withdraw"}
        onClick={handleItemClick}
      />
      <Menu.Item
        name="calendar"
        active={activeItem === "calendar"}
        onClick={handleItemClick}
      />
      <Menu.Item
        name="Settings"
        active={activeItem === "settings"}
        onClick={handleItemClick}
      />
    </Menu>
  );
};

export default Header;
