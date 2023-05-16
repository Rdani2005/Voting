import React from "react";
import FilterYear from "./FilterYear";
import FilterSpec from "./FilterSpec";

const Filters = () => {
    return (
        <div className="flex justify-between">
            <FilterYear></FilterYear>
            <FilterSpec></FilterSpec>
        </div>
    );
};

export default Filters;
