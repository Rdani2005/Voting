"use client";
import GetAllParties from "@/Services/GetAllParties";
import { usePoliticalPartiesContext } from "@/app/context/PoliticalStore";
import { FunctionComponent, useEffect } from "react";

const PoliticalTable = () => {
    const { politicalParties, setPoliticalParties } =
        usePoliticalPartiesContext();

    useEffect(() => {
        GetAllParties()
            .then((data) => {
                console.log(JSON.stringify(data));
                setPoliticalParties(data);
            })
            .catch((err) => console.log(err));
    }, []);

    return (
        <section className="overflow-x-auto sm:-mx-6 lg:-mx-8">
            <div className="inline-block min-w-full py-2 sm:px-6 lg:px-8">
                <div className="overflow-hidden">
                    <table className="min-w-full text-left text-sm font-light">
                        <thead className="border-b font-medium dark:border-neutral-500">
                            <tr>
                                <th scope="col" className="px-6 py-4">
                                    Nombre del Partido
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Bandera
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Mascota
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {politicalParties.map((p, i) => (
                                <PoliticalPartyRow
                                    id={p.id}
                                    imageUrl={p.imageUrl}
                                    name={p.name}
                                    petUrl={p.petUrl}
                                    key={i}
                                />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    );
};

const PoliticalPartyRow: FunctionComponent<PoliticalPartyModel> = (party) => {
    console.log(JSON.stringify(party));

    return (
        <tr className="border-b transition duration-300 ease-in-out hover:bg-neutral-100 ">
            <td className="whitespace-nowrap px-6 py-4 font-medium">
                {party.name}
            </td>
            <td className="whitespace-nowrap px-6 py-4">
                <img src={party.imageUrl} alt="" className="w-1/2" />
            </td>
            <td className="whitespace-nowrap px-6 py-4">
                <img src={party.petUrl} alt="" className="w-1/2" />
            </td>
        </tr>
    );
};

export default PoliticalTable;
