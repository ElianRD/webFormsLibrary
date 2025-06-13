<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/Clientes/Site1.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="CRUDOnboarding.Clientes.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
        <div class="layout-content-container flex flex-col max-w-[960px] flex-1">
            <div class="px-4 py-3">
                <label class="flex flex-col min-w-40 h-12 w-full">
                    <div class="flex w-full flex-1 items-stretch rounded-lg h-full">
                        <div
                            class="text-[#49739c] flex border-none bg-[#e7edf4] items-center justify-center pl-4 rounded-l-lg border-r-0"
                            data-icon="MagnifyingGlass"
                            data-size="24px"
                            data-weight="regular">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
                                <path
                                    d="M229.66,218.34l-50.07-50.06a88.11,88.11,0,1,0-11.31,11.31l50.06,50.07a8,8,0,0,0,11.32-11.32ZM40,112a72,72,0,1,1,72,72A72.08,72.08,0,0,1,40,112Z">
                                </path>
                            </svg>
                        </div>
                        <input
                            placeholder="Search for books"
                            class="form-input flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-lg text-[#0d141c] focus:outline-0 focus:ring-0 border-none bg-[#e7edf4] focus:border-none h-full placeholder:text-[#49739c] px-4 rounded-l-none border-l-0 pl-2 text-lg font-normal leading-normal"
                            value="" />
                    </div>
                </label>
            </div>
            <h2 class="text-[#0d141c] text-[22px] font-bold leading-tight tracking-[-0.015em] px-4 pb-3 pt-5">Featured Books</h2>
            <div class="grid grid-cols-[repeat(auto-fit,minmax(158px,1fr))] gap-3 p-4">
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuCSQiGc326z5-ZwRhMOeVMrHSCfyFWqwlrB-WolsFuixIBlPh4HE91j-h9oLivSsX57h6Y9NvyxZ9E0jWHgnDOUHB3N8QlzoSLUmNHrRd6pLFwx8MHGxTmHLnyJsGiNRa6z6EPkZqzIi7AQBirkkfTQ1PU1N3oF1HtIurJnmZqAXHDk1Ekj5piITcRXSVlX_a_-u8d9hO33_1nVgUq_u_INIsbEnpniqsqxFwj1-YlIHII_Oq7DsWOQ6KIm2XgH45HDlwTnjST_gPw");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">The Secret Garden</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">Frances Hodgson Burnett</p>
                    </div>
                </div>
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuAVYlmkXPx5y7zkGu2DsP4L4b5Wi_nTEze7Q73aYa8IuEjgsFZrX0T98yyocM18BCXb87HdIAFjkVBEShzfTKffPJlfIwMkQvj_lY8ViYMyICHTAC8EwqtnFBFZeKbqP8jML8xMcp-Ahb6RLbfxoR13NEpLrhgRyC3ynFF2l9zj4ioJI9fClBnTTf_g_YrleJwcMfL481LJjyD3EqKpFG55nq0BTcYtO2fdoS8w7VySH4oh9ACEVPQYJYR2MiX82yDY9oO4VU9Nn4A");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">Pride and Prejudice</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">Jane Austen</p>
                    </div>
                </div>
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBep7qNwnCnhECGAdABLw-jrIbrxvbtU_CpY2Ze1i1I539RWF0jaBMP-A6IECsYDJA3G1lscooNh3pP9e6GCeaGzySP3rkxalfMvsWPoSJsNjsFKT7Ik06mvQlRBc3BNZW-3p3sakIpn3frQ1jjNhOTXcprS8WLCMGfvMFzWWEWG6Q4WKdGoauuto_NZNW3aZyTqLbz5yJ10iRnKBRHfTmIgSmHntRsd85Cv3xxjWNyBjMElIhZjomzXRKa95_PwlP_ayJLnJ71bns");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">To Kill a Mockingbird</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">Harper Lee</p>
                    </div>
                </div>
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuCWWYCi_OaQGjPqLvWBPQQkThIzmDXo9X5cGivwhYuUjVfSWH-kD8-GHR40X8I-x-40aOw0MH10siiBcCy8tAWR4eQJqCzxZyXpEZoRXGr_oLaq9PGTe2FZ5GBbA9-pQKxGxnem8CFlCuXi7SlWOfsTGJgXehNEBmbo1QjpxiohhgRxhHAszNyRTI5IRZ4Iwjnhun9zoUEUkcD-qCYfDuV8SWw6ZGUYXYsQT5AIDXJ6ByHCnBlysraSO5f_6Wk9pbY_dDWaNunSnAE");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">1984</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">George Orwell</p>
                    </div>
                </div>
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBso5lFib0XIy_5rkxTx45zdfXfV3TLKToCmiXyoUY0Nw7z21JFSSmrhZw-2N7K09XXzczXMIdUlMq44PAACAA_qsiBfYXdxjACylWFT7hkxSVzqbfKT1cHtUWdUEe1PQQepe8ht9VdG1vRmiNtU-6FaYLp-hEcaQe4tmrk7x6GNMSh4rZzERosl9XPkJ3Cn6qILHpf7BXae7NOeP5eIE8nitIPMjslx7rdm2W1YayCWfFjZC8EG-M_xmXOpx2MlKuAZp-_n9cQXMk");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">The Great Gatsby</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">F. Scott Fitzgerald</p>
                    </div>
                </div>
                <div class="flex flex-col gap-3 pb-3">
                    <div
                        class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-lg"
                        style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBAV5UhEg6HrdyVGyh2R5Dy88QebvNasWnAr7VnHcEDFsATSLVa-PvaoJ_-B4fBHIonR0HgEpFg74zyjXAyDgSUiWm71AXHMkLpBu_t4lQ5a7ST3MkKizOlx4IA1K-ivYXtwRQure9BJBFZzWdUYXLQwKGFSxJtjPnMZamUcxh86t5E5giOQJ7gA_EnR8jh_fhEMXxIMhxTYTSvZDnrWesmnys0klq0HgyI-TUAVkegbxWaJtrL1K2Wrx5AAEQEu4YkiidUKpd2Mys");'>
                    </div>
                    <div>
                        <p class="text-[#0d141c] text-lg font-medium leading-normal">Moby Dick</p>
                        <p class="text-[#49739c] text-sm font-normal leading-normal">Herman Melville</p>
                    </div>
                </div>
            </div>
        </div>
    

</asp:Content>
