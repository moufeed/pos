const local_dist = "./Localization";
const local_src = "./web-tools/src/Localization";



let header = `
msgid ""
msgstr ""
"Project-Id-Version: <%= pkg.name %> <%= pkg.version %>"
"Last-Translator: tantum <support@tantumproj.com>"
"MIME-Version: 1.0"
"Content-Type: text/plain; charset=UTF-8"
"Content-Transfer-Encoding: 8bit"
"Plural-Forms: nplurals=2; plural=(n != 1);"
"POT-Creation-Date:"
"PO-Revision-Date:"
"Language-Team:"
`;

module.exports = {
    dist : local_dist,
    src : local_src,
    header:header,
    files :[
        {
            "output" : "en.po",
            "inputs" :[
                `${local_src}/en/admin.po`,
                `${local_src}/en/portal.po`,
                `${local_src}/en/identity.po`,
                `${local_src}/en/custom.po`
            ]
        },
         {
        "output" : "ar.po",
        "inputs" :[
            `${local_src}/ar/admin.po`,
            `${local_src}/ar/portal.po`,
            `${local_src}/ar/identity.po`,
            `${local_src}/ar/custom.po`
        ]
    }
]
}