"use client";

import { useGlobalContext } from "@/app/context/Store";
import axios from "axios";
import React, { useContext, useState } from "react";

type CreateYearModel = {
    Name: String;
};

type CreateYearResponse = {
    id: Number;
    name: String;
};

// Sending post request to the server
export async function CreateYear(
    NewYear: CreateYearModel
): Promise<CreateYearResponse> {
    console.log("--> Sending new Year to the server!");
    try {
        const { data, status } = await axios.post<CreateYearResponse>(
            "http://localhost:5251/api/v1/years",
            NewYear,
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

// Rendering the form
const AddYear = () => {
    const [yearName, setYearName] = useState<String>("");

    const { availableYears, setAvailableYears } = useGlobalContext();

    const HandleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        CreateYear({ Name: yearName })
            .then((data) => {
                setAvailableYears([
                    ...availableYears,
                    { id: data.id, name: data.name },
                ]);
            })

            .catch((error) => {
                console.log(error);
            });
    };

    return (
        <div className="">
            <form
                className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4"
                onSubmit={(e) => HandleSubmit(e)}
            >
                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="yearName"
                    >
                        Nombre Del Año
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="yearName"
                        type="text"
                        placeholder="Ej: Duodecimo"
                        onChange={(e) => setYearName(e.target.value)}
                        required
                    />
                </div>

                <div className="flex items-center justify-center">
                    <button
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        type="submit"
                    >
                        Registrar Año
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddYear;
