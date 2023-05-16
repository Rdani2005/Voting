"use client";

import GetAllSpecialties from "@/Services/GetAllSpecialties";
import { useGlobalContext } from "@/app/context/Store";

import React, { useEffect } from "react";

const FilterSpec = () => {
    const { availableSpec, setAvailableSpec } = useGlobalContext();

    useEffect(() => {
        GetAllSpecialties()
            .then((specs) => setAvailableSpec(specs))
            .catch((err) => console.log(err));
    }, []);

    return (
        <select className="w-56 text-black">
            {availableSpec.map((spec, i) => (
                <option key={i}>{spec.name}</option>
            ))}
        </select>
    );
};

export default FilterSpec;
