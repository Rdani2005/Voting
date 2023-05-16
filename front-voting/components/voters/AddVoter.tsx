"use client";

import { useGlobalContext } from "@/app/context/Store";
import axios from "axios";
import React, { useState } from "react";

type CreateVoterModel = {
    Identification: String;
    Name: String;
    LastName: String;
    YearId: Number;
    SpecialtyId: Number;
};

type CreateVoterResponse = {
    id: Number;
    name: String;
    lastName: String;
    year: YearModel;
    specialty: SpecialtyModel;
    createdAt: string;
};
// Sending post request to the server
async function CreateVoter(NewVoter: CreateVoterModel) {
    console.log("--> Sending new Voter to the server!");
    try {
        const { data, status } = await axios.post<CreateVoterResponse>(
            "http://localhost:5251/api/v1/votantes/",
            NewVoter,
            {
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                },
            }
        );
        console.log(JSON.stringify(data, null, 4));
        console.log(status);
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            // 👇️ error: AxiosError<any, any>
            throw new Error(error.message);
        } else {
            console.log("unexpected error: ", error);
            throw new Error("An unexpected error occurred");
        }
    }
}

const AddVoter = () => {
    const [Name, setName] = useState<String>("");
    const [Identification, setIdentification] = useState<String>("");
    const [LastName, setLastName] = useState<String>("");
    const [YearId, setYearId] = useState<Number>(1);
    const [SpecialtyId, setSpecialtyId] = useState<Number>(1);

    const { availableYears, availableSpec, voters, setVoters } =
        useGlobalContext();

    const [successful, setSuccessfull] = useState<boolean>(false);

    const HandleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log(YearId);
        console.log(SpecialtyId);
        CreateVoter({
            Identification,
            Name,
            LastName,
            YearId,
            SpecialtyId,
        })
            .then((data) => {
                setVoters([
                    ...voters,
                    {
                        id: data.id,
                        identification: Identification,
                        name: data.name,
                        lastName: data.lastName,
                        specialty: data.specialty,
                        year: data.year,
                    },
                ]);
                setSuccessfull(true);
            })
            .catch((err) => console.log(err));
    };

    return (
        <div className="col-span-2">
            {successful && (
                <div className=" text-white bg-green-500 shadow appearance-none border rounded w-full py-2 px-3 leading-tight focus:outline-none focus:shadow-outline">
                    <h1>Votante agregado con éxito</h1>
                </div>
            )}
            <form
                className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4"
                onSubmit={(e) => HandleSubmit(e)}
            >
                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="identificaton"
                    >
                        Identificacion del Votante
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="identificaton"
                        type="text"
                        placeholder="Ej: 0000-0000-0000"
                        onChange={(e) => {
                            setIdentification(e.target.value);
                            setSuccessfull(false);
                        }}
                        required
                    />
                </div>

                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="name"
                    >
                        Nombre Del Votante
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="name"
                        type="text"
                        placeholder="Ej: Danny Ricardo"
                        onChange={(e) => {
                            setName(e.target.value);
                            setSuccessfull(false);
                        }}
                        required
                    />
                </div>

                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="lastName"
                    >
                        Apellido Del Votante
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="lastName"
                        type="text"
                        placeholder="Ej: Villalobos"
                        onChange={(e) => {
                            setLastName(e.target.value);
                            setSuccessfull(false);
                        }}
                        required
                    />
                </div>

                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="yearName"
                    >
                        Año del Votante
                    </label>
                    <select
                        name="voterYear"
                        id="voterYear"
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        onChange={(e) => {
                            setYearId(+e.target.value);
                            setSuccessfull(false);
                        }}
                    >
                        {availableYears.map((spec, i) => {
                            return (
                                <option value={`${spec.id}`} key={i}>
                                    {spec.name}
                                </option>
                            );
                        })}
                    </select>
                </div>

                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="yearName"
                    >
                        Especialidad del Votante
                    </label>
                    <select
                        name="voterSpec"
                        id="voterSpec"
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        onChange={(e) => {
                            setSpecialtyId(+e.target.value);
                            setSuccessfull(false);
                        }}
                    >
                        {availableSpec.map((spec, i) => {
                            return (
                                <option value={`${spec.id}`} key={i}>
                                    {spec.name}
                                </option>
                            );
                        })}
                    </select>
                </div>

                <div className="flex items-center justify-center">
                    <button
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        type="submit"
                    >
                        Registrar Votante
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddVoter;
