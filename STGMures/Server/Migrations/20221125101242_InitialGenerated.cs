using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StgMures.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialGenerated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsociatedDiseases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsociatedDiseases", x => x.ID);
                },
                comment: "Contains the list of posible associated diseases a patient may have.\r\nThe primary disease usualy is a serious heart condition which determine the associated ones");

            migrationBuilder.CreateTable(
                name: "ConsumableCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableCategory", x => x.ID);
                },
                comment: "type of consumables used in surgery");

            migrationBuilder.CreateTable(
                name: "DiagnosticCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Medical conditions types / groups - uzually the name of the web page"),
                    Type = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false, comment: "Values: PRIMARY; SECONDARY; ATI; OTHER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalGroup", x => x.ID);
                },
                comment: "Categories: gruping the diagnoses");

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "optional: medic' seal"),
                    Specialty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                },
                comment: "Will be sincronised with users table; Medical staff is managed by NOW another app, but that may change");

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true, comment: "Social Security Number; Romanian CNP is 13 digits length; Newborns may not have it"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Prenume"),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "NUme"),
                    CNASCode = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Data nasterii"),
                    Sex = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Grupa Sangvina"),
                    ParentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "General comments"),
                    ChildOrAdult = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, defaultValueSql: "(N'COPIL')", comment: "COPIL = child; Not directly related to age but to the specific of the medical procedures")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                },
                comment: "Patient details; contains only 'fixed details' the variable ones (like weight, height, BMI...) are included in patient's file");

            migrationBuilder.CreateTable(
                name: "SurgicalProcedure",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgicalProcedure", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Consumable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Design = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true, comment: "biolog; mecanic"),
                    ValueFormat = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    ValueType = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false, comment: "SUBSTANCE;DEVICE;CONSUMABLE;"),
                    MeasureUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Descriptive field")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consumable_ConsumableCategory",
                        column: x => x.CategoryID,
                        principalTable: "ConsumableCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Diagnostic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ValueType may be ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    DiagnosticCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Name of the diagnostic"),
                    ValueFormat = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false, comment: "Determine the other fields usage: Note, MinAlert, MaxAlert "),
                    MinAlertValue = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true, comment: "Min alert value (normal values between min and max); "),
                    MaxAlertValue = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true, comment: "Max alert value (normal values between min and max)"),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MeasureUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCondition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diagnostic_DiagnosticCategory",
                        column: x => x.DiagnosticCategoryID,
                        principalTable: "DiagnosticCategory",
                        principalColumn: "ID");
                },
                comment: "Contains the list of possible diagnostics. \r\nIt is a circular database: a diagnostic can have parent (parentID is not null).\r\nA diagnostic can have multiple 'child diagnostics' (not viceversa), and I will limit the number of levels to 4.\r\nIf parent ID is not null, ValueType is ignored (null or 'p').\r\n");

            migrationBuilder.CreateTable(
                name: "MedicPatient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MedicID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicPatient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicPatient_Medic",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MedicPatient_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID");
                },
                comment: "Many-to-Many relationship patient-medic");

            migrationBuilder.CreateTable(
                name: "PatientAssocDiseases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    AsociatedDiseaseID = table.Column<int>(type: "int", nullable: false, comment: "Act as a short description"),
                    Symptom = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IntraSurgery = table.Column<bool>(type: "bit", nullable: true, comment: "Determined intra-surgery")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAssocDiseases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientAssocDiseases_AsociatedDiseases",
                        column: x => x.AsociatedDiseaseID,
                        principalTable: "AsociatedDiseases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PatientAssocDiseases_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PatientFile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    FileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "File no asigned by user "),
                    FileDate = table.Column<DateTime>(type: "date", nullable: true),
                    HospitalAdmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    ATITakeOverDate = table.Column<DateTime>(type: "date", nullable: true),
                    ATIRetakeoverDate = table.Column<DateTime>(type: "date", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BMI = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BSA = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AnotherHospitalAdmission = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WardTransferDate = table.Column<DateTime>(type: "date", nullable: true, comment: "Data transferului pe sectie"),
                    DischargeDate = table.Column<DateTime>(type: "date", nullable: true),
                    WardDays = table.Column<short>(type: "smallint", nullable: true, comment: "In theory it may be calculated; but refer hospital day, not calendaristic day"),
                    ATIDays = table.Column<short>(type: "smallint", nullable: true, comment: "In theory it may be calculated; but refer hospital day, not calendaristic day")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientFile_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID");
                },
                comment: "A patient usually has one file; but if it comes again, it may be useful to have patient's history");

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentCategoryID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ValueType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdministrationMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Defaul admin method (dosage, perfusion...) ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Treatment_TreatmentCategory",
                        column: x => x.TreatmentCategoryID,
                        principalTable: "TreatmentCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PatientDiagnostic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false, comment: "optional; PatientFile is enough"),
                    PatientFileID = table.Column<int>(type: "int", nullable: false),
                    DiagnosticID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Value = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true, comment: "Value is formated acording to diagnostic.ValueFormat"),
                    ShortNote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyObservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientDiagnostic_Diagnostic",
                        column: x => x.DiagnosticID,
                        principalTable: "Diagnostic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PatientDiagnostic_PatientFile",
                        column: x => x.PatientFileID,
                        principalTable: "PatientFile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PatientSurgery",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    PatientFileID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false, comment: "Date of the surgery"),
                    IncisionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Incision type"),
                    Duration = table.Column<int>(type: "int", nullable: true, comment: "Minutes"),
                    CECDuration = table.Column<int>(type: "int", nullable: true, comment: "Minutes"),
                    AorticClampDuration = table.Column<int>(type: "int", nullable: true, comment: "Minutes"),
                    Reoperation = table.Column<bool>(type: "bit", nullable: true, comment: "Yes/No (null=NoNo=No; any other obs means Yes)"),
                    Complications = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReoperationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSurgery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientSurgery_PatientFile",
                        column: x => x.PatientFileID,
                        principalTable: "PatientFile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PatientTreatment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    PatientDiagnosticID = table.Column<int>(type: "int", nullable: true, comment: "The treatment may be related to a specific diagnostic. or not"),
                    TreatmentType = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false, comment: "Tratament (default); Anestezie;CEC;PRIMARY; SECONDARY; ATI; OTHER"),
                    NoOfDays = table.Column<int>(type: "int", nullable: true),
                    WeekSchema = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: true),
                    Dosage = table.Column<decimal>(type: "decimal(7,3)", nullable: false),
                    DosageQtty = table.Column<decimal>(type: "decimal(10,3)", nullable: true, defaultValueSql: "((1))"),
                    DosageTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Administration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DosageNote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTreatment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Treatment",
                        column: x => x.TreatmentID,
                        principalTable: "Treatment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CEC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    PatientSurgeryID = table.Column<int>(type: "int", nullable: false),
                    BypasDuration = table.Column<int>(type: "int", nullable: false),
                    BypasTemperature = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    AorticClampingDuration = table.Column<int>(type: "int", nullable: true),
                    AorticClampingTemperature = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Flow = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Priming = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Oxigenator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MUFF = table.Column<bool>(type: "bit", nullable: true),
                    Ultrafiltering = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEC", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CEC_PatientSurgery",
                        column: x => x.PatientSurgeryID,
                        principalTable: "PatientSurgery",
                        principalColumn: "ID");
                },
                comment: "extracorporeal circulation");

            migrationBuilder.CreateTable(
                name: "Surgery",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SurgicalProcedureID = table.Column<int>(type: "int", nullable: false),
                    PatientSurgeryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Surgery_PatientSurgery",
                        column: x => x.PatientSurgeryID,
                        principalTable: "PatientSurgery",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Surgery_SurgicalProcedure",
                        column: x => x.SurgicalProcedureID,
                        principalTable: "SurgicalProcedure",
                        principalColumn: "ID");
                },
                comment: "Intersection table: one surgery can have many procedures");

            migrationBuilder.CreateTable(
                name: "SurgeryAnesthesia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    PatientFileID = table.Column<int>(type: "int", nullable: false),
                    PatientSurgeryID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryAnesthesia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurgeryAnesthesia_PatientSurgery",
                        column: x => x.PatientSurgeryID,
                        principalTable: "PatientSurgery",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PatientDailyTreatment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    AdministrationTime = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Dosage = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    DosageQtty = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTreatment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientDailyTreatment_PatientTreatment",
                        column: x => x.TreatmentID,
                        principalTable: "PatientTreatment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CECConsumable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CECID = table.Column<int>(type: "int", nullable: false),
                    ConsumableID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    ShortNote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CECConsumable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CECConsumable_CEC",
                        column: x => x.CECID,
                        principalTable: "CEC",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CECConsumable_Consumable",
                        column: x => x.ConsumableID,
                        principalTable: "Consumable",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AnesthesiaConsumable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SurgeryAnesthesiaID = table.Column<int>(type: "int", nullable: false),
                    ConsumableID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    ShortNote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnesthesiaConsumable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnesthesiaConsumable_Consumable",
                        column: x => x.ConsumableID,
                        principalTable: "Consumable",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AnesthesiaConsumable_SurgeryAnesthesia",
                        column: x => x.SurgeryAnesthesiaID,
                        principalTable: "SurgeryAnesthesia",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnesthesiaConsumable_ConsumableID",
                table: "AnesthesiaConsumable",
                column: "ConsumableID");

            migrationBuilder.CreateIndex(
                name: "IX_AnesthesiaConsumable_SurgeryAnesthesiaID",
                table: "AnesthesiaConsumable",
                column: "SurgeryAnesthesiaID");

            migrationBuilder.CreateIndex(
                name: "IX_AsociatedDiseases",
                table: "AsociatedDiseases",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_CEC_PatientSurgeryID",
                table: "CEC",
                column: "PatientSurgeryID");

            migrationBuilder.CreateIndex(
                name: "IX_CECConsumable_CECID",
                table: "CECConsumable",
                column: "CECID");

            migrationBuilder.CreateIndex(
                name: "IX_CECConsumable_ConsumableID",
                table: "CECConsumable",
                column: "ConsumableID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_CategoryID",
                table: "Consumable",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostic_DiagnosticCategoryID",
                table: "Diagnostic",
                column: "DiagnosticCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPatient_MedicID",
                table: "MedicPatient",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPatient_PatientID",
                table: "MedicPatient",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAssocDiseases_AsociatedDiseaseID",
                table: "PatientAssocDiseases",
                column: "AsociatedDiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAssocDiseases_PatientID",
                table: "PatientAssocDiseases",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDailyTreatment_TreatmentID",
                table: "PatientDailyTreatment",
                column: "TreatmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnostic_DiagnosticID",
                table: "PatientDiagnostic",
                column: "DiagnosticID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnostic_PatientFileID",
                table: "PatientDiagnostic",
                column: "PatientFileID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_PatientID",
                table: "PatientFile",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_PatientFileID",
                table: "PatientSurgery",
                column: "PatientFileID");

            migrationBuilder.CreateIndex(
                name: "AK_PatientTreatment",
                table: "PatientTreatment",
                column: "TreatmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatment_PatientID",
                table: "PatientTreatment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_PatientSurgeryID",
                table: "Surgery",
                column: "PatientSurgeryID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_SurgicalProcedureID",
                table: "Surgery",
                column: "SurgicalProcedureID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryAnesthesia_PatientSurgeryID",
                table: "SurgeryAnesthesia",
                column: "PatientSurgeryID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_TreatmentCategoryID",
                table: "Treatment",
                column: "TreatmentCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnesthesiaConsumable");

            migrationBuilder.DropTable(
                name: "CECConsumable");

            migrationBuilder.DropTable(
                name: "MedicPatient");

            migrationBuilder.DropTable(
                name: "PatientAssocDiseases");

            migrationBuilder.DropTable(
                name: "PatientDailyTreatment");

            migrationBuilder.DropTable(
                name: "PatientDiagnostic");

            migrationBuilder.DropTable(
                name: "Surgery");

            migrationBuilder.DropTable(
                name: "SurgeryAnesthesia");

            migrationBuilder.DropTable(
                name: "CEC");

            migrationBuilder.DropTable(
                name: "Consumable");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "AsociatedDiseases");

            migrationBuilder.DropTable(
                name: "PatientTreatment");

            migrationBuilder.DropTable(
                name: "Diagnostic");

            migrationBuilder.DropTable(
                name: "SurgicalProcedure");

            migrationBuilder.DropTable(
                name: "PatientSurgery");

            migrationBuilder.DropTable(
                name: "ConsumableCategory");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "DiagnosticCategory");

            migrationBuilder.DropTable(
                name: "PatientFile");

            migrationBuilder.DropTable(
                name: "TreatmentCategory");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
