"use client";
import AddPoliticalParty, {
    AxiosHttpService,
} from "@/components/political/AddPoliticalParty";
import PoliticalTable from "@/components/political/PoliticalTable";
import React from "react";

const page = () => (
    <main className="px-20 py-32">
        <PoliticalTable></PoliticalTable>
        <AddPoliticalParty httpService={new AxiosHttpService()} />
    </main>
);

export default page;
