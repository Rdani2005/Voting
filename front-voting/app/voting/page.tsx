"use client";
import PoliticalCard from "@/components/PoliticalCard";
import React, { FunctionComponent, useEffect, useState } from "react";
import { useVoterContext } from "../context/VoterStore";
import { redirect } from "next/navigation";
import GetAllParties from "@/Services/GetAllParties";

const page = () => {
    const { actualVoter, setActualVoter } = useVoterContext();
    useEffect(() => {
        if (actualVoter == null) {
            redirect("/");
        }
    }, []);

    const { parties } = PartiesHook();

    return (
        <main>
            <h1 className="text-2xl text-center font-semibold mt-5 text-gray-700">
                Escoja el partido por el que desea votar
            </h1>
            <PartyList parties={parties} />
        </main>
    );
};

type MultipleParties = {
    parties: Array<PoliticalPartyModel>;
};

const PartyList: FunctionComponent<MultipleParties> = ({ parties }) => (
    <section className="grid md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-11 px-10 py-20">
        {parties.map((p, i) => (
            <PoliticalCard
                id={p.id}
                petUrl={p.petUrl}
                imageUrl={p.imageUrl}
                name={p.name}
                key={i}
            />
        ))}
    </section>
);

export default page;

const PartiesHook = () => {
    const [parties, setParties] = useState<PoliticalPartyModel[] | []>([]);

    useEffect(() => {
        GetAllParties().then((data) => setParties(data));
    }, []);

    return { parties };
};
