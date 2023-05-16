"use client";

import GetAllYears from "@/Services/GetAllYears";
import { useGlobalContext } from "@/app/context/Store";
import React, { useEffect } from "react";

const FilterYear = () => {
    const { availableYears, setAvailableYears } = useGlobalContext();

    useEffect(() => {
        GetAllYears()
            .then((years) => {
                setAvailableYears(years);
            })
            .catch((err) => console.log(err));
    }, []);

    return (
        <select className="w-56">
            {availableYears.map((spec, i) => {
                return <option key={i}>{spec.name}</option>;
            })}
        </select>
    );
};

export default FilterYear;
