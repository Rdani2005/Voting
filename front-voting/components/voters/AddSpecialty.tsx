"use client";

import { useGlobalContext } from "@/app/context/Store";
import axios from "axios";
import React, { useState } from "react";

type CreateSpecialty = {
    Name: String;
};

type CreateSpecialtyModel = {
    id: Number;
    name: String;
    createdAt: string;
};
// Sending post request to the server
export async function createSpecialty(
    newSpecialty: CreateSpecialty
): Promise<CreateSpecialtyModel> {
    console.log("--> Sending new Specialty to the server!");

    try {
        const { data, status } = await axios.post<CreateSpecialtyModel>(
            "http://localhost:5251/api/v1/specialties",
            newSpecialty,
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

const AddSpecialty = () => {
    const [specialtyName, setSpecialtyName] = useState<String>("");

    const { availableSpec, setAvailableSpec } = useGlobalContext();

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        createSpecialty({ Name: specialtyName })
            .then((data) => {
                setAvailableSpec([
                    ...availableSpec,
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
                onSubmit={(e) => handleSubmit(e)}
            >
                <div className="mb-4">
                    <label
                        className="block text-gray-700 text-sm font-bold mb-2"
                        htmlFor="specialtyName"
                    >
                        Nombre De la Especialidad
                    </label>
                    <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="yearName"
                        type="text"
                        placeholder="Ej: Desarrollo de Software"
                        onChange={(e) => setSpecialtyName(e.target.value)}
                        required
                    />
                </div>

                <div className="flex items-center justify-center">
                    <button
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        type="submit"
                    >
                        Registrar Especialidad
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddSpecialty;
