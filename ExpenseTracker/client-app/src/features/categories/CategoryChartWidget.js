import React from "react";
import { PieChart } from "react-minimal-pie-chart";


const CategoryChartWidget = (props) => {
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

export default CategoryChartWidget;
