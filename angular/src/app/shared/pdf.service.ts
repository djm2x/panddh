// // import { Commande } from './../myModels/models';
// import { Injectable } from '@angular/core';
// // import pdfMake from 'pdfmake/build/pdfmake';
// // import pdfFonts from 'pdfmake/build/vfs_fonts';

// import * as moment from 'moment';
// import * as pdfMake from 'pdfmake/build/pdfmake';
// import * as pdfFonts from 'pdfmake/build/vfs_fonts';
// import { TDocumentDefinitions, Content } from 'pdfmake/build/pdfmake';
// import { getRtlScrollAxisType } from '@angular/cdk/platform';
// // pdfMake.vfs = pdfFonts.pdfMake.vfs;

// @Injectable({
//   providedIn: 'root'
// })
// export class PdfService {
//   // doc https://pdfmake.github.io/docs/document-definition-object/images/
//   // play arround http://pdfmake.org/playground.html
//   constructor() { }

//   generatePdf(commande: any, format) {

//     const myBody: any[][] = [['Référence', 'Désignation', 'Quantité', 'Unité', 'PU TTC', 'Montant TTC']];
//     const fs = 9;
//     const corps = commande.detailCmds.forEach(e => {
//       myBody.push([
//         { text: e.article.code },
//         { text: e.article.titreFr },
//         { text: e.qtePrise },
//         { text: e.article.unite },
//         { text: e.prixVente },
//         { text: e.total }]);
//     });

//     const myLayout = {
//       hLineWidth(i, node) {
//         return (i === 0 || i === node.table.body.length) ? 0.7 : 0.7;
//       },
//       vLineWidth(i, node) {
//         return (i === 0 || i === node.table.widths.length) ? 0.7 : 0.7;
//       },
//       // hLineColor: function (i, node) {
//       //   return (i === 0 || i === node.table.body.length) ? 'black' : 'gray';
//       // },
//       // vLineColor: function (i, node) {
//       //   return (i === 0 || i === node.table.widths.length) ? 'black' : 'gray';
//       // },
//       // hLineStyle: function (i, node) { return {dash: { length: 10, space: 4 }}; },
//       // vLineStyle: function (i, node) { return {dash: { length: 10, space: 4 }}; },
//       // paddingLeft: function(i, node) { return 4; },
//       // paddingRight: function(i, node) { return 4; },
//       // paddingTop: function(i, node) { return 2; },
//       // paddingBottom: function(i, node) { return 2; },
//       // fillColor: function (rowIndex, node, columnIndex) { return null; }
//     };


//     // https://www.base64-image.de/
//     console.log(myBody);
//     // return
//     const pdf = pdfMake;
//     pdf.vfs = pdfFonts.pdfMake.vfs;
//     const documentDefinition: TDocumentDefinitions = {
//       pageSize: format === 'A5' ? { width: 419.53, height: 595.28 } : { width: 297.64, height: 419.53 },
//       pageMargins: [15, 10],
//       defaultStyle: {
//         fontSize: 7,
//         color: 'rgb(43, 43, 43)',
//       },
//       content: [
//         {
//           // alignment: 'justify',
//           style: 'heightStyle',
//           columns: [
//             {
//               image: this.image64(),
//               width: 80,
//               style: 'image'
//             },
//             {
//               margin: [125, 0, 0, 0],
//               text: [
//                 'Comptoir de Vente\n',
//                 'to the paragraph and have \n',
//                 { text: 'Motorisation ' },
//                 { text: 'Alpha motors & ', bold: true },
//                 { text: 'Somfy ', italics: true, color: 'green' },
//               ]
//             }
//           ]
//         },
//         {
//           alignment: 'justify',
//           style: 'heightStyle',
//           columns: [
//             {
//               style: 'tableExample2',
//               layout: myLayout,
//               // color: '#444',
//               table: {
//                 widths: ['*', '*'],
//                 headerRows: 1,
//                 // keepWithHeaderRows: 1,
//                 body: [
//                   [{ text: 'BON DE LIVRAISON', style: 'tableHeader', colSpan: 2, alignment: 'left' }, {}],
//                   ['Numero', commande.id],
//                   ['Date', moment(new Date()).format('DD/MM/YYYY')],
//                   [`Chargé d'affaire`, 'Commercial'],
//                   // [{text: 'rowSpan '}, 'Sample value 2', 'Sample value 3'],
//                   // [{text: 'rowSpan '}, 'Sample value 2', 'Sample value 3'],
//                 ]
//               }
//             },
//             {
//               style: ['tableExample', 'colorStyle'],
//               margin: [10, 5, 0, 0],
//               // color: '#444',
//               table: {
//                 widths: ['*'],
//                 layout: myLayout,
//                 // heights: 100,
//                 // headerRows: 0,
//                 // keepWithHeaderRows: 1,
//                 body: [
//                   // [{ text: 'rowSpan\n\ndddd\n\nssss', rowSpan: 1, /* fillColor: '#eeeeff'*/}],
//                   [
//                     {
//                       text: [
//                         `Client : ${commande.client ? commande.client : commande.nomClient}\n\n`,
//                         'Tel \n\n',
//                         'Inf \n',
//                       ],
//                       // rowSpan: 1
//                     }
//                   ],
//                 ],
//               }
//             }
//           ]
//         },
//         {
//           // layout: 'lightHorizontalLines', // optional
//           // style: 'font',
//           table: {
//             // headers are automatically repeated if the table spans over multiple pages
//             // you can declare how many rows should be treated as headers
//             headerRows: 1,
//             widths: [30, 'auto', 30, 30, 40, '*'],

//             body: myBody,

//           },
//           layout: myLayout
//         },
//         {
//           alignment: 'justify',
//           columns: [
//             {
//               style: 'tableExample',
//               layout: myLayout,
//               table: {
//                 body: [
//                   ['Crédit'],
//                   [0]
//                 ]
//               }
//             },
//             {
//               text: ''
//             },
//             {
//               style: 'tableExample',
//               layout: myLayout,
//               table: {
//                 body: [
//                   ['Escompte', 'Total TTC'],
//                   [0, commande.total]
//                 ]
//               }
//             }
//           ]
//         },
//         {
//           style: 'tableExample',
//           table: {
//             layout: myLayout,
//             widths: ['*', '*', '*', '*', '*'],
//             body: [
//               ['Mode', 'Référence', 'Porteur', 'Banque', 'Montant'],
//               ['Espece', '', '', '', commande.total]
//             ]
//           }
//         },
//         {
//           style: ['tableExample', 'widthStyle'],
//           table: {
//             layout: myLayout,
//             widths: ['*', '*', '*'],
//             body: [
//               [
//                 { text: 'Visa : ', rowSpan: 2, alignment: 'left' },
//                 { text: 'Visa client : ', rowSpan: 2, alignment: 'left' },
//                 { text: 'Visa : ', alignment: 'left' },
//               ],
//               [
//                 {},
//                 {},
//                 { text: '\n', alignment: 'left' },
//               ],
//             ]
//           }
//         },
//         {
//           style: ['tableExample',],
//           table: {
//             layout: myLayout,
//             widths: ['*'],
//             body: [
//               [
//                 {
//                   text: `Edité par : Commercial Assia - Le : ${moment(new Date()).format('DD/MM/YYYY HH:mm:ss')} - P.(1/1)`,
//                   alignment: 'right',
//                   border: [false, true, false, true],
//                   fontSize: 8,
//                 },
//               ],
//             ]
//           }
//         },
//         {
//           text: `This paragraph uses header style \nand extends the alignment property`,
//           fontSize: 8,
//           alignment: 'left'
//         }
//         // '\n\n',
//         // { text: `Total : ${commande.total}`, style: 'header' },
//       ],
//       styles: {
//         colorStyle: {
//           // color: 'gray',
//           // background: 'gray'
//         },
//         font: {
//           fontSize: 8,
//           alignment: 'center'
//         },
//         image: {
//           alignment: 'center'
//         },
//         header: {
//           fontSize: 18,
//           bold: true,
//           margin: [0, 0, 0, 10]
//         },
//         subheader: {
//           fontSize: 16,
//           bold: true,
//           margin: [0, 10, 0, 5]
//         },
//         tableExample: {
//           margin: [0, 5, 0, 15]
//         },
//         tableExample2: {
//           margin: [0, 5, 0, 15],
//           width: 100
//         },
//         heightStyle: {
//           height: 100,
//         },
//         widthStyle: {
//           width: 100,
//         },
//         tableHeader: {
//           bold: true,
//           fontSize: 13,
//           color: 'black'
//         }
//       }



//     };
//     pdf.createPdf(documentDefinition).open();





//   }

//   image64 = () => 'data:image/png;base64,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';
// }
// // {
// // 	'4A0': [4767.87, 6740.79],
// // 	'2A0': [3370.39, 4767.87],
// // 	A0: [2383.94, 3370.39],
// // 	A1: [1683.78, 2383.94],
// // 	A2: [1190.55, 1683.78],
// // 	A3: [841.89, 1190.55],
// // 	A4: [595.28, 841.89],
// // 	A5: [419.53, 595.28],
// // 	A6: [297.64, 419.53],
// // 	A7: [209.76, 297.64],
// // 	A8: [147.40, 209.76],
// // 	A9: [104.88, 147.40],
// // 	A10: [73.70, 104.88],
// // 	B0: [2834.65, 4008.19],
// // 	B1: [2004.09, 2834.65],
// // 	B2: [1417.32, 2004.09],
// // 	B3: [1000.63, 1417.32],
// // 	B4: [708.66, 1000.63],
// // 	B5: [498.90, 708.66],
// // 	B6: [354.33, 498.90],
// // 	B7: [249.45, 354.33],
// // 	B8: [175.75, 249.45],
// // 	B9: [124.72, 175.75],
// // 	B10: [87.87, 124.72],
// // 	C0: [2599.37, 3676.54],
// // 	C1: [1836.85, 2599.37],
// // 	C2: [1298.27, 1836.85],
// // 	C3: [918.43, 1298.27],
// // 	C4: [649.13, 918.43],
// // 	C5: [459.21, 649.13],
// // 	C6: [323.15, 459.21],
// // 	C7: [229.61, 323.15],
// // 	C8: [161.57, 229.61],
// // 	C9: [113.39, 161.57],
// // 	C10: [79.37, 113.39],
// // 	RA0: [2437.80, 3458.27],
// // 	RA1: [1729.13, 2437.80],
// // 	RA2: [1218.90, 1729.13],
// // 	RA3: [864.57, 1218.90],
// // 	RA4: [609.45, 864.57],
// // 	SRA0: [2551.18, 3628.35],
// // 	SRA1: [1814.17, 2551.18],
// // 	SRA2: [1275.59, 1814.17],
// // 	SRA3: [907.09, 1275.59],
// // 	SRA4: [637.80, 907.09],
// // 	EXECUTIVE: [521.86, 756.00],
// // 	FOLIO: [612.00, 936.00],
// // 	LEGAL: [612.00, 1008.00],
// // 	LETTER: [612.00, 792.00],
// // 	TABLOID: [792.00, 1224.00]
// // };
