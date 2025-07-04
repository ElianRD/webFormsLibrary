﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CRUDOnboarding.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="preconnect" href="https://fonts.gstatic.com/" crossorigin="" />
<link rel="stylesheet" href="https://fonts.googleapis.com/css2?display=swap&amp;family=Newsreader:wght@400;500;700;800&amp;family=Noto+Sans:wght@400;500;700;900" />


<title>Stitch Design</title>
<link rel="icon" type="image/x-icon" href="data:image/x-icon;base64," />

<script src="https://cdn.tailwindcss.com?plugins=forms,container-queries"></script>
</head>
  <body>
    <div class="relative flex size-full min-h-screen flex-col bg-gray-50 group/design-root overflow-x-hidden" style='font-family: Newsreader, "Noto Sans", sans-serif;'>
      <div class="layout-container flex h-full grow flex-col">
        <header class="flex items-center justify-between whitespace-nowrap border-b border-solid border-b-[#eaedf1] px-10 py-3">
          <div class="flex items-center gap-4 text-[#101518]">
            <div class="size-4">
              <svg viewBox="0 0 48 48" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M4 4H17.3334V17.3334H30.6666V30.6666H44V44H4V4Z" fill="currentColor"></path></svg>
            </div>
            <h2 class="text-[#101518] text-lg font-bold leading-tight tracking-[-0.015em]">Book Haven</h2>
          </div>
          <div class="flex flex-1 justify-end gap-8">
            <div class="flex items-center gap-9">
              <a class="text-[#101518] text-sm font-medium leading-normal" href="#">Books</a>
              <a class="text-[#101518] text-sm font-medium leading-normal" href="#">Categories</a>
              <a class="text-[#101518] text-sm font-medium leading-normal" href="#">About Us</a>
              <a class="text-[#101518] text-sm font-medium leading-normal" href="#">Contact</a>
            </div>
            <button
              class="flex max-w-[480px] cursor-pointer items-center justify-center overflow-hidden rounded-xl h-10 bg-[#eaedf1] text-[#101518] gap-2 text-sm font-bold leading-normal tracking-[0.015em] min-w-0 px-2.5"
            >
              <div class="text-[#101518]" data-icon="MagnifyingGlass" data-size="20px" data-weight="regular">
                <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" fill="currentColor" viewBox="0 0 256 256">
                  <path d="M229.66,218.34l-50.07-50.06a88.11,88.11,0,1,0-11.31,11.31l50.06,50.07a8,8,0,0,0,11.32-11.32ZM40,112a72,72,0,1,1,72,72A72.08,72.08,0,0,1,40,112Z"></path>
                </svg>
              </div>
            </button>
            <div
              class="bg-center bg-no-repeat aspect-square bg-cover rounded-full size-10"
              style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuCInt7365jmShkHFFUwbqA_tfG8Cb8OyU1XXhjtukA0Ao2qyVdZHlN-pKfPhkz9wXaFNCllPQ_LSuoaXRgRc3JbobRNSLT0ExtmVPdM-W9SbsfEUnC4I7LctZjMrujvvj1gQCofsIwCitDhqNnXa36pPkjalMOYNXGrVWl5TvtxOqwS8Gk-bXMTkmMfE6lnXabcM-bdT5nuYRGb5VTMViBFpsfH2ykqHsx8PfIsRwTKIWbA4GKXsnemZZA4QzDFSizv3PtVhlUF0w8");'
            ></div>
          </div>
        </header>
        <div class="px-40 flex flex-1 justify-center py-5">
          <div class="layout-content-container flex flex-col max-w-[960px] flex-1">
            <div class="px-4 py-3">
              <label class="flex flex-col min-w-40 h-12 w-full">
                <div class="flex w-full flex-1 items-stretch rounded-xl h-full">
                  <div
                    class="text-[#5c748a] flex border-none bg-[#eaedf1] items-center justify-center pl-4 rounded-l-xl border-r-0"
                    data-icon="MagnifyingGlass"
                    data-size="24px"
                    data-weight="regular"
                  >
                    <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
                      <path
                        d="M229.66,218.34l-50.07-50.06a88.11,88.11,0,1,0-11.31,11.31l50.06,50.07a8,8,0,0,0,11.32-11.32ZM40,112a72,72,0,1,1,72,72A72.08,72.08,0,0,1,40,112Z"
                      ></path>
                    </svg>
                  </div>
                  <input
                    placeholder="Search for books"
                    class="form-input flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-xl text-[#101518] focus:outline-0 focus:ring-0 border-none bg-[#eaedf1] focus:border-none h-full placeholder:text-[#5c748a] px-4 rounded-l-none border-l-0 pl-2 text-base font-normal leading-normal"
                    value=""
                  />
                </div>
              </label>
            </div>
            <h2 class="text-[#101518] text-[22px] font-bold leading-tight tracking-[-0.015em] px-4 pb-3 pt-5">Featured Books</h2>
            <div class="grid grid-cols-[repeat(auto-fit,minmax(158px,1fr))] gap-3 p-4">
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuCSQiGc326z5-ZwRhMOeVMrHSCfyFWqwlrB-WolsFuixIBlPh4HE91j-h9oLivSsX57h6Y9NvyxZ9E0jWHgnDOUHB3N8QlzoSLUmNHrRd6pLFwx8MHGxTmHLnyJsGiNRa6z6EPkZqzIi7AQBirkkfTQ1PU1N3oF1HtIurJnmZqAXHDk1Ekj5piITcRXSVlX_a_-u8d9hO33_1nVgUq_u_INIsbEnpniqsqxFwj1-YlIHII_Oq7DsWOQ6KIm2XgH45HDlwTnjST_gPw");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">The Secret Garden</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">Frances Hodgson Burnett</p>
                </div>
              </div>
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuAVYlmkXPx5y7zkGu2DsP4L4b5Wi_nTEze7Q73aYa8IuEjgsFZrX0T98yyocM18BCXb87HdIAFjkVBEShzfTKffPJlfIwMkQvj_lY8ViYMyICHTAC8EwqtnFBFZeKbqP8jML8xMcp-Ahb6RLbfxoR13NEpLrhgRyC3ynFF2l9zj4ioJI9fClBnTTf_g_YrleJwcMfL481LJjyD3EqKpFG55nq0BTcYtO2fdoS8w7VySH4oh9ACEVPQYJYR2MiX82yDY9oO4VU9Nn4A");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">Pride and Prejudice</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">Jane Austen</p>
                </div>
              </div>
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBep7qNwnCnhECGAdABLw-jrIbrxvbtU_CpY2Ze1i1I539RWF0jaBMP-A6IECsYDJA3G1lscooNh3pP9e6GCeaGzySP3rkxalfMvsWPoSJsNjsFKT7Ik06mvQlRBc3BNZW-3p3sakIpn3frQ1jjNhOTXcprS8WLCMGfvMFzWWEWG6Q4WKdGoauuto_NZNW3aZyTqLbz5yJ10iRnKBRHfTmIgSmHntRsd85Cv3xxjWNyBjMElIhZjomzXRKa95_PwlP_ayJLnJ71bns");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">To Kill a Mockingbird</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">Harper Lee</p>
                </div>
              </div>
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuCWWYCi_OaQGjPqLvWBPQQkThIzmDXo9X5cGivwhYuUjVfSWH-kD8-GHR40X8I-x-40aOw0MH10siiBcCy8tAWR4eQJqCzxZyXpEZoRXGr_oLaq9PGTe2FZ5GBbA9-pQKxGxnem8CFlCuXi7SlWOfsTGJgXehNEBmbo1QjpxiohhgRxhHAszNyRTI5IRZ4Iwjnhun9zoUEUkcD-qCYfDuV8SWw6ZGUYXYsQT5AIDXJ6ByHCnBlysraSO5f_6Wk9pbY_dDWaNunSnAE");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">1984</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">George Orwell</p>
                </div>
              </div>
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBso5lFib0XIy_5rkxTx45zdfXfV3TLKToCmiXyoUY0Nw7z21JFSSmrhZw-2N7K09XXzczXMIdUlMq44PAACAA_qsiBfYXdxjACylWFT7hkxSVzqbfKT1cHtUWdUEe1PQQepe8ht9VdG1vRmiNtU-6FaYLp-hEcaQe4tmrk7x6GNMSh4rZzERosl9XPkJ3Cn6qILHpf7BXae7NOeP5eIE8nitIPMjslx7rdm2W1YayCWfFjZC8EG-M_xmXOpx2MlKuAZp-_n9cQXMk");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">The Great Gatsby</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">F. Scott Fitzgerald</p>
                </div>
              </div>
              <div class="flex flex-col gap-3 pb-3">
                <div
                  class="w-full bg-center bg-no-repeat aspect-[3/4] bg-cover rounded-xl"
                  style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuBAV5UhEg6HrdyVGyh2R5Dy88QebvNasWnAr7VnHcEDFsATSLVa-PvaoJ_-B4fBHIonR0HgEpFg74zyjXAyDgSUiWm71AXHMkLpBu_t4lQ5a7ST3MkKizOlx4IA1K-ivYXtwRQure9BJBFZzWdUYXLQwKGFSxJtjPnMZamUcxh86t5E5giOQJ7gA_EnR8jh_fhEMXxIMhxTYTSvZDnrWesmnys0klq0HgyI-TUAVkegbxWaJtrL1K2Wrx5AAEQEu4YkiidUKpd2Mys");'
                ></div>
                <div>
                  <p class="text-[#101518] text-base font-medium leading-normal">Moby Dick</p>
                  <p class="text-[#5c748a] text-sm font-normal leading-normal">Herman Melville</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <footer class="flex justify-center">
          <div class="flex max-w-[960px] flex-1 flex-col">
            <footer class="flex flex-col gap-6 px-5 py-10 text-center @container">
              <div class="flex flex-wrap items-center justify-center gap-6 @[480px]:flex-row @[480px]:justify-around">
                <a class="text-[#5c748a] text-base font-normal leading-normal min-w-40" href="#">Terms of Service</a>
                <a class="text-[#5c748a] text-base font-normal leading-normal min-w-40" href="#">Privacy Policy</a>
                <a class="text-[#5c748a] text-base font-normal leading-normal min-w-40" href="#">Contact Us</a>
              </div>
              <div class="flex flex-wrap justify-center gap-4">
                <a href="#">
                  <div class="text-[#5c748a]" data-icon="TwitterLogo" data-size="24px" data-weight="regular">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
                      <path
                        d="M247.39,68.94A8,8,0,0,0,240,64H209.57A48.66,48.66,0,0,0,168.1,40a46.91,46.91,0,0,0-33.75,13.7A47.9,47.9,0,0,0,120,88v6.09C79.74,83.47,46.81,50.72,46.46,50.37a8,8,0,0,0-13.65,4.92c-4.31,47.79,9.57,79.77,22,98.18a110.93,110.93,0,0,0,21.88,24.2c-15.23,17.53-39.21,26.74-39.47,26.84a8,8,0,0,0-3.85,11.93c.75,1.12,3.75,5.05,11.08,8.72C53.51,229.7,65.48,232,80,232c70.67,0,129.72-54.42,135.75-124.44l29.91-29.9A8,8,0,0,0,247.39,68.94Zm-45,29.41a8,8,0,0,0-2.32,5.14C196,166.58,143.28,216,80,216c-10.56,0-18-1.4-23.22-3.08,11.51-6.25,27.56-17,37.88-32.48A8,8,0,0,0,92,169.08c-.47-.27-43.91-26.34-44-96,16,13,45.25,33.17,78.67,38.79A8,8,0,0,0,136,104V88a32,32,0,0,1,9.6-22.92A30.94,30.94,0,0,1,167.9,56c12.66.16,24.49,7.88,29.44,19.21A8,8,0,0,0,204.67,80h16Z"
                      ></path>
                    </svg>
                  </div>
                </a>
                <a href="#">
                  <div class="text-[#5c748a]" data-icon="FacebookLogo" data-size="24px" data-weight="regular">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
                      <path
                        d="M128,24A104,104,0,1,0,232,128,104.11,104.11,0,0,0,128,24Zm8,191.63V152h24a8,8,0,0,0,0-16H136V112a16,16,0,0,1,16-16h16a8,8,0,0,0,0-16H152a32,32,0,0,0-32,32v24H96a8,8,0,0,0,0,16h24v63.63a88,88,0,1,1,16,0Z"
                      ></path>
                    </svg>
                  </div>
                </a>
                <a href="#">
                  <div class="text-[#5c748a]" data-icon="InstagramLogo" data-size="24px" data-weight="regular">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
                      <path
                        d="M128,80a48,48,0,1,0,48,48A48.05,48.05,0,0,0,128,80Zm0,80a32,32,0,1,1,32-32A32,32,0,0,1,128,160ZM176,24H80A56.06,56.06,0,0,0,24,80v96a56.06,56.06,0,0,0,56,56h96a56.06,56.06,0,0,0,56-56V80A56.06,56.06,0,0,0,176,24Zm40,152a40,40,0,0,1-40,40H80a40,40,0,0,1-40-40V80A40,40,0,0,1,80,40h96a40,40,0,0,1,40,40ZM192,76a12,12,0,1,1-12-12A12,12,0,0,1,192,76Z"
                      ></path>
                    </svg>
                  </div>
                </a>
              </div>
              <p class="text-[#5c748a] text-base font-normal leading-normal">@2024 Book Haven. All rights reserved.</p>
            </footer>
          </div>
        </footer>
      </div>
    </div>
  </body>
</html>

