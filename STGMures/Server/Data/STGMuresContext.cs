﻿// Commented all relationhips between tables (no FK)
// Fk will be assured by code;  not by EF, not by database
// 

#nullable enable
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Data;

public partial class StgMuresContext : DbContext
{
    public StgMuresContext()
    {
    }

    public StgMuresContext(DbContextOptions<StgMuresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnesthesiaConsumable> AnesthesiaConsumables { get; set; }

    public virtual DbSet<Cec> Cecs { get; set; }

    public virtual DbSet<CecConsumable> CecConsumables { get; set; }

    public virtual DbSet<Consumable> Consumables { get; set; }

    public virtual DbSet<ConsumableCategory> ConsumableCategories { get; set; }

    public virtual DbSet<Diagnostic> Diagnostics { get; set; }

    public virtual DbSet<DiagnosticCategory> DiagnosticCategories { get; set; }

    public virtual DbSet<Medic> Medics { get; set; }

    public virtual DbSet<MedicPatient> MedicPatients { get; set; }

    public virtual DbSet<Param> Params { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAssocDisease> PatientAssocDiseases { get; set; }

    public virtual DbSet<PatientDailyTreatment> PatientDailyTreatments { get; set; }

    public virtual DbSet<PatientDiagnostic> PatientDiagnostics { get; set; }

    public virtual DbSet<PatientFile> PatientFiles { get; set; }

    public virtual DbSet<PatientSurgery> PatientSurgeries { get; set; }

    public virtual DbSet<PatientTreatment> PatientTreatments { get; set; }

    public virtual DbSet<Surgery> Surgeries { get; set; }

    public virtual DbSet<SurgeryAnesthesium> SurgeryAnesthesia { get; set; }

    public virtual DbSet<SurgicalCategory> SurgicalCategories { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TreatmentCategory> TreatmentCategories { get; set; }
/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CRIS55\\SQLEXPRESS;Initial Catalog=STGMures;Integrated Security=True");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnesthesiaConsumable>(entity =>
        {
            entity.ToTable("AnesthesiaConsumable");

              

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.ConsumableId).HasColumnName("ConsumableID");
            entity.Property(e => e.NumericValue)
                .HasDefaultValueSql("((0))")
                .HasComment("Computed from Value, if the Format is type Numeric")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.ShortNote).HasMaxLength(250);
            entity.Property(e => e.SurgeryAnesthesiaId).HasColumnName("SurgeryAnesthesiaID");
            entity.Property(e => e.Value).HasMaxLength(50);
/*
            entity.HasOne(d => d.Consumable).WithMany(p => p.AnesthesiaConsumables)
                .HasForeignKey(d => d.ConsumableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnesthesiaConsumable_Consumable");

            entity.HasOne(d => d.SurgeryAnesthesia).WithMany(p => p.AnesthesiaConsumables)
                .HasForeignKey(d => d.SurgeryAnesthesiaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnesthesiaConsumable_SurgeryAnesthesia");
*/
        });

        modelBuilder.Entity<Cec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CEC");

            entity.ToTable("Cec", tb => tb.HasComment("extracorporeal circulation"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.AorticClampingTemperature).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.AorticClampingTemperatureTop)
                .HasComment("It may be an interval; first version will only suport the medium value (Celsius)")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.BypasTemperature).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.BypasTemperatureTop)
                .HasComment("It may be an interval; first version will only suport the medium value (Celsius)")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Flow).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Muff).HasColumnName("MUFF");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.Oxigenator).HasMaxLength(50);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PatientSurgeryId).HasColumnName("SurgeryID");
            entity.Property(e => e.Priming).HasColumnType("decimal(10, 3)");

            /*
            entity.HasOne(d => d.PatientSurgery).WithMany(p => p.Cecs)
                .HasForeignKey(d => d.PatientSurgeryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CEC_PatientSurgery");
            */
        });

        modelBuilder.Entity<CecConsumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CECConsumable");

            entity.ToTable("CecConsumable");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Cecid).HasColumnName("CECID");
            entity.Property(e => e.ConsumableId).HasColumnName("ConsumableID");
            entity.Property(e => e.NumericValue)
                .HasDefaultValueSql("((0))")
                .HasComment("Computed from Value, if the Format is type Numeric")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.ShortNote).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(50);
/*
            entity.HasOne(d => d.Cec).WithMany(p => p.CecConsumables)
                .HasForeignKey(d => d.Cecid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CECConsumable_CEC");

            entity.HasOne(d => d.Consumable).WithMany(p => p.CecConsumables)
                .HasForeignKey(d => d.ConsumableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CECConsumable_Consumable");
*/
        });

        modelBuilder.Entity<Consumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Material");

            entity.ToTable("Consumable");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Design)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'BIOLOGIC')")
                .HasComment("biolog; mecanic");
            entity.Property(e => e.MeasureUnit)
                .HasMaxLength(50)
                .HasComment("Descriptive field");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("SUBSTANCE;DEVICE;CONSUMABLE;");
            entity.Property(e => e.ValueFormat).HasMaxLength(50);

/*            entity.HasOne(d => d.Category).WithMany(p => p.Consumables)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumable_ConsumableCategory"); */
        });

        modelBuilder.Entity<ConsumableCategory>(entity =>
        {
            entity.ToTable("ConsumableCategory", tb => tb.HasComment("type of consumables used in surgery"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.MeasureUnit)
                .HasMaxLength(50)
                .HasComment("Default measure unit if any; but it may be used another one (subdivision / concentration...) at affective use of the consumable");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MedicalCondition");

            entity.ToTable("Diagnostic", tb => tb.HasComment("Contains the list of possible diagnostics. \r\nIt is a circular database: a diagnostic can have parent (parentID is not null).\r\nA diagnostic can have multiple 'child diagnostics' (not viceversa), and I will limit the number of levels to 4.\r\nIf parent ID is not null, ValueType is ignored (null or 'p').\r\n"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd()
                .HasComment("ValueType may be ")
                .HasColumnName("ID");
            entity.Property(e => e.DiagnosticCategoryId).HasColumnName("DiagnosticCategoryID");
            entity.Property(e => e.MaxAlertValue)
                .HasMaxLength(50)
                .HasComment("Max alert value (normal values between min and max); NOT USED");
            entity.Property(e => e.MeasureUnit).HasMaxLength(50);
            entity.Property(e => e.MinAlertValue)
                .HasMaxLength(50)
                .HasComment("Min alert value (normal values between min and max); NOT USED");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasComment("Effective value if any");
            entity.Property(e => e.NumericValue).HasColumnType("decimal(10, 3)");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasComment("Name of the diagnostic");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.ValueFormat)
                .HasMaxLength(50)
                .HasComment("Determine the other fields usage: Note, MinAlert, MaxAlert ");
/*
            entity.HasOne(d => d.DiagnosticCategory).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.DiagnosticCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagnostic_DiagnosticCategory");
  */
            });

        modelBuilder.Entity<DiagnosticCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MedicalGroup");

            entity.ToTable("DiagnosticCategory", tb => tb.HasComment("Categories: gruping the diagnoses"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasComment("Medical conditions types / groups - uzually the name of the web page");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("Values: PRIMARY; SECONDARY; ATI; ASOCIATEDDESEASE;OTHER");
        });

        modelBuilder.Entity<Medic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Doctor");

            entity.ToTable("Medic", tb => tb.HasComment("Will be sincronised with users table; Medical staff is managed by NOW another app, but that may change"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("optional: medic' seal");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PasswordSalt).HasMaxLength(512);
            entity.Property(e => e.Specialty).HasMaxLength(150);
        });

        modelBuilder.Entity<MedicPatient>(entity =>
        {
            entity.ToTable("MedicPatient", tb => tb.HasComment("Many-to-Many relationship patient-medic"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.MedicId).HasColumnName("MedicID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.RegistrationDate)
                .HasComment("Optional: to register when the relation medic-patient changed")
                .HasColumnType("smalldatetime");
/*
            entity.HasOne(d => d.Medic).WithMany(p => p.MedicPatients)
                .HasForeignKey(d => d.MedicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicPatient_Medic");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicPatient_Patient");
*/
        });

        modelBuilder.Entity<Param>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Param", tb => tb.HasComment("Contains default parameters used in app. Critical pamaters are hard coded, but they can be extended if required"));

            entity.Property(e => e.Critical)
                .HasDefaultValueSql("((1))")
                .HasComment("Usually only critical params will be added");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Separated by ;")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(250);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient", tb => tb.HasComment("Patient details; contains only 'fixed details' the variable ones (like weight, height, BMI...) are included in patient's file"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.BirthDate)
                .HasComment("Data nasterii")
                .HasColumnType("date");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(50)
                .HasComment("Grupa Sangvina");
            entity.Property(e => e.Cnascode)
                .HasMaxLength(50)
                .HasColumnName("CNASCode");
            entity.Property(e => e.Cnp)
                .HasMaxLength(50)
                .HasComment("Social Security Number; Romanian CNP is 13 digits length; Newborns may not have it")
                .HasColumnName("CNP");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasComment("Prenume");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasComment("NUme");
            entity.Property(e => e.MotherBloodGroup).HasMaxLength(50);
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasComment("General comments");
            entity.Property(e => e.ParentsName).HasMaxLength(150);
            entity.Property(e => e.Sex).HasMaxLength(50);
        });

        modelBuilder.Entity<PatientAssocDisease>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.DiagnosticId)
                .HasComment("Act as a short description")
                .HasColumnName("DiagnosticID");
            entity.Property(e => e.IntraSurgery).HasComment("Determined intra-surgery or normal investigation");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Symptom).HasMaxLength(1000);

            /*
            entity.HasOne(d => d.Diagnostic).WithMany(p => p.PatientAssocDiseases)
                .HasForeignKey(d => d.DiagnosticId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAssocDiseases_Diagnostic");
            
            entity.HasOne(d => d.Patient).WithMany(p => p.PatientAssocDiseases)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAssocDiseases_Patient");
*/
        });

        modelBuilder.Entity<PatientDailyTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DailyTreatment");

            entity.ToTable("PatientDailyTreatment");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.AdministrationTime)
                .HasComment("Date and Hour of administering the substances")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.DosageNumeric).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.DosageQtty).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasComment("Medical observations due treatment administration if any");
            entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");
/*
            entity.HasOne(d => d.Treatment).WithMany(p => p.PatientDailyTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDailyTreatment_PatientTreatment");
*/
        });

        modelBuilder.Entity<PatientDiagnostic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DailyObservation");

            entity.ToTable("PatientDiagnostic");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiagnosticId).HasColumnName("DiagnosticID");
            entity.Property(e => e.IntraSurgery).HasComment("Preoperator=0r; intraoperator/intrasurgery=1 (in time of the surgery or before)");
            entity.Property(e => e.NumericValue).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.PatientFileId).HasColumnName("PatientFileID");
            entity.Property(e => e.PatientId)
                .HasComment("optional; PatientFile is enough")
                .HasColumnName("PatientID");
            entity.Property(e => e.ShortNote).HasMaxLength(250);
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasComment("Value is formated acording to diagnostic.ValueFormat");
        });

        modelBuilder.Entity<PatientFile>(entity =>
        {
            entity.ToTable("PatientFile", tb => tb.HasComment("A patient usually has one file; but if it comes again, it may be useful to have patient's history"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.AnotherHospitalAdmission).HasMaxLength(250);
            entity.Property(e => e.Atidays)
                .HasComment("In theory it may be calculated; but refer hospital day, not calendaristic day")
                .HasColumnName("ATIDays");
            entity.Property(e => e.AtiRetakeOverDate)
                .HasColumnType("date")
                .HasColumnName("ATIRetakeOverDate");
            entity.Property(e => e.AtiTakeOverDate)
                .HasColumnType("date")
                .HasColumnName("ATITakeOverDate");
            entity.Property(e => e.Bmi)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("BMI");
            entity.Property(e => e.Bsa)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("BSA");
            entity.Property(e => e.DischargeDate).HasColumnType("date");
            entity.Property(e => e.FileDate).HasColumnType("date");
            entity.Property(e => e.FileNumber)
                .HasMaxLength(50)
                .HasComment("File no asigned by user ");
            entity.Property(e => e.Height).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.HospitalAdmissionDate).HasColumnType("date");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.WardDays).HasComment("In theory it may be calculated; but refer hospital day, not calendaristic day");
            entity.Property(e => e.WardRetransferDate).HasColumnType("date");
            entity.Property(e => e.WardTransferDate)
                .HasComment("Data transferului pe sectie")
                .HasColumnType("date");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 3)");
/*
            entity.HasOne(d => d.Patient).WithMany(p => p.PatientFiles)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientFile_Patient");
*/
        });

        modelBuilder.Entity<PatientSurgery>(entity =>
        {
            entity.ToTable("PatientSurgery");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.AorticClampDuration).HasComment("Minutes");
            entity.Property(e => e.CecDuration)
                .HasComment("Minutes")
                .HasColumnName("CECDuration");
            entity.Property(e => e.Complications).HasMaxLength(1000);
            entity.Property(e => e.Date)
                .HasComment("Date of the surgery")
                .HasColumnType("date");
            entity.Property(e => e.Duration).HasComment("Minutes");
            entity.Property(e => e.IncisionType)
                .HasMaxLength(50)
                .HasComment("Incision type");
            entity.Property(e => e.PatientFileId).HasColumnName("PatientFileID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.SurgeryId).HasColumnName("SurgeryID");
            entity.Property(e => e.Reoperation).HasComment("Yes/No (null=NoNo=No; any other obs means Yes)");
            entity.Property(e => e.ReoperationDate).HasColumnType("date");

            /*
            entity.HasOne(d => d.PatientFile).WithMany(p => p.PatientSurgeries)
                .HasForeignKey(d => d.PatientFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientSurgery_PatientFile");
            */
        });

        modelBuilder.Entity<PatientTreatment>(entity =>
        {
            entity.ToTable("PatientTreatment");

            entity.HasIndex(e => e.TreatmentId, "AK_PatientTreatment");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Administration).HasMaxLength(50);
            entity.Property(e => e.Dosage).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.DosageQtty)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.DosageTotal).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.PatientDiagnosticId)
                .HasComment("The treatment may be related to a specific diagnostic. or not")
                .HasColumnName("PatientDiagnosticID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");
            entity.Property(e => e.TreatmentType)
                .HasMaxLength(50)
                .HasComment("Tratament (default); Anestezie;CEC;PRIMARY; SECONDARY; ATI; OTHER");
            entity.Property(e => e.WeekSchema)
                .HasMaxLength(7)
                .HasDefaultValueSql("((1111111))")
                .IsFixedLength()
                .HasComment("It represent a bit field: 1 or 0 for each day of the week ");

            /*
            entity.HasOne(d => d.Patient).WithMany(p => p.PatientTreatments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientTreatment_Patient");

            entity.HasOne(d => d.Treatment).WithMany(p => p.PatientTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientTreatment_Treatment");
            */
        });

        modelBuilder.Entity<Surgery>(entity =>
        {
            entity.ToTable("Surgery", tb => tb.HasComment("Intersection table: one surgery can have many procedures"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(250);
            // entity.Property(e => e.SurgeryId).HasColumnName("SurgeryID");
            entity.Property(e => e.SurgicalCategoryId).HasColumnName("SurgicalCategoryID");

            /*
            entity.HasOne(d => d.PatientSurgery).WithMany(p => p.Surgeries)
                .HasForeignKey(d => d.PatientSurgeryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Surgery_PatientSurgery");

            entity.HasOne(d => d.SurgicalCategory).WithMany(p => p.Surgeries)
                .HasForeignKey(d => d.SurgicalCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Surgery_SurgicalProcedure");
            */
        });

        modelBuilder.Entity<SurgeryAnesthesium>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PatientFileId).HasColumnName("PatientFileID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PatientSurgeryId).HasColumnName("SurgeryID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("generala;locoreginala;bloc paravertrebral;bloc parasternal;");

            /*
            entity.HasOne(d => d.PatientSurgery).WithMany(p => p.SurgeryAnesthesia)
                .HasForeignKey(d => d.PatientSurgeryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurgeryAnesthesia_PatientSurgery");
            */
        });

        modelBuilder.Entity<SurgicalCategory>(entity =>
        {
            entity.ToTable("SurgicalCategory");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.ToTable("Treatment");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.AdministrationMethod)
                .HasMaxLength(50)
                .HasComment("Default admin method (dosage, perfusion...) ");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.TreatmentCategoryId).HasColumnName("TreatmentCategoryID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.ValueFormat).HasMaxLength(50);
            entity.Property(e => e.MeasureUnit).HasMaxLength(50);


            /*
            entity.HasOne(d => d.TreatmentCategory).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.TreatmentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Treatment_TreatmentCategory");
            */
        });

        modelBuilder.Entity<TreatmentCategory>(entity =>
        {
            entity.ToTable("TreatmentCategory");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasComment("description of treatment category");
            entity.Property(e => e.Type).HasMaxLength(50);

        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingGeneratedFunctions(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}