/*
 *  Defines the medical procedure that could be performed on a patient
 *  Author:     Payam F @ 2021-12-05
 */
public enum MedicalTest
{
    // Imaging
    X_Ray = 0,
    CT_Scan =1,
    MRI = 2,
    PET_Scan = 3,
    Ultrasonography = 4,
    Angiography = 5,

    // Endoscopies
    Bronchoscopy = 6,
    Gastroscopy = 7,
    Colonoscopy = 8,
    Cystoscopy = 9,
    Colposcopy = 10,
    Arthroscopy = 11,
    Laparoscopy = 12,
    Thoracoscopy = 13,

    // Lab analysis
    CBC = 14,
    Metabolic_Panel = 15,
    Coagulation_Panel = 16,
    Urinalysis = 17,
    Stool_Exam = 18,
    Other_Liquid_Test = 19,
    Tissue_Biopsy = 20,
    Genetic_Test = 21,

    // Body function test
    EKG = 22,
    EEG = 23,
    ABG = 24,
    Pulmunary_Function = 25
}