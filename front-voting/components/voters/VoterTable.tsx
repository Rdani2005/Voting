"use client";

import { GetAllVoters } from "@/Services/GetAllUsers";
import { useGlobalContext } from "@/app/context/Store";
import React, { FunctionComponent, useEffect } from "react";

const VoterTable = () => {
    const { voters, setVoters } = useGlobalContext();

    useEffect(() => {
        GetAllVoters()
            .then((specs) => setVoters(specs))
            .catch((err) => console.log(err));
    }, []);

    return (
        <div className="overflow-x-auto sm:-mx-6 lg:-mx-8">
            <div className="inline-block min-w-full py-2 sm:px-6 lg:px-8">
                <div className="overflow-hidden">
                    <table className="min-w-full text-left text-sm font-light">
                        <thead className="border-b font-medium dark:border-neutral-500">
                            <tr>
                                <th scope="col" className="px-6 py-4">
                                    Nombre
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Apellidos
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Año
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Especialidad
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {voters.map((v, i) => (
                                <VoterRow
                                    key={i}
                                    id={v.id}
                                    identification={v.identification}
                                    lastName={v.lastName}
                                    name={v.name}
                                    specialty={v.specialty}
                                    year={v.year}
                                />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

const VoterRow: FunctionComponent<VotersModel> = (voter) => {
    console.log(JSON.stringify(voter, null, 4));

    return (
        <tr className="border-b transition duration-300 ease-in-out hover:bg-neutral-100 ">
            <td className="whitespace-nowrap px-6 py-4 font-medium">
                {voter.name}
            </td>
            <td className="whitespace-nowrap px-6 py-4">{voter.lastName}</td>
            <td className="whitespace-nowrap px-6 py-4">{voter.year.name}</td>
            <td className="whitespace-nowrap px-6 py-4">
                {voter.specialty.name}
            </td>
        </tr>
    );
};

export default VoterTable;
