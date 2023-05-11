import PoliticalCard from "@/components/PoliticalCard";
import React, { FunctionComponent } from "react";

const parties: Array<PoliticalPartyModel> = [
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
    {
        imgUrl: "https://www.monumental.co.cr/wp-content/uploads/2023/01/PLN-bandera1.jpg",
        name: "Partido Liberación Nacional",
    },
];

const page = () => {
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
            <PoliticalCard imgUrl={p.imgUrl} name={p.name} key={i} />
        ))}
    </section>
);

export default page;
