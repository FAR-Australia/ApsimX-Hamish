﻿// -----------------------------------------------------------------------
// <copyright file="Model.cs" company="APSIM Initiative">
//     Copyright (c) APSIM Initiative
// </copyright>
//-----------------------------------------------------------------------
namespace Models.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Base class for all models
    /// </summary>
    [Serializable]
    public class Model : IModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model" /> class.
        /// </summary>
        public Model()
        {
            this.Name = GetType().Name;
            this.IsHidden = false;
            this.Children = new List<Model>();
        }

        /// <summary>
        /// Gets or sets the name of the model
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of child models.   
        /// </summary>
        [XmlElement(typeof(Simulation))]
        [XmlElement(typeof(Simulations))]
        [XmlElement(typeof(Zone))]
        [XmlElement(typeof(Model))]
        [XmlElement(typeof(ModelCollectionFromResource))]
        [XmlElement(typeof(Models.Agroforestry.LocalMicroClimate))]
        [XmlElement(typeof(Models.Agroforestry.TreeProxy))]
        [XmlElement(typeof(Models.Agroforestry.AgroforestrySystem))]
        [XmlElement(typeof(Models.Graph.Graph))]
        [XmlElement(typeof(Models.Graph.Series))]
        [XmlElement(typeof(Models.Graph.Regression))]
        [XmlElement(typeof(Models.Graph.EventNamesOnGraph))]
        [XmlElement(typeof(Models.PMF.Plant))]
        [XmlElement(typeof(Models.PMF.OilPalm.OilPalm))]
        [XmlElement(typeof(Models.Soils.Soil))]
        [XmlElement(typeof(Models.SurfaceOM.SurfaceOrganicMatter))]
        [XmlElement(typeof(AgPastureProto))]
        [XmlElement(typeof(AgPasture.SwardProto))]
        [XmlElement(typeof(AgPasture.PastureSpeciesSwd))]
        [XmlElement(typeof(AgPasture.Sward))]
        [XmlElement(typeof(AgPasture.PastureSpecies))]
        [XmlElement(typeof(Clock))]
        [XmlElement(typeof(DataStore))]
        [XmlElement(typeof(Fertiliser))]
        [XmlElement(typeof(Models.PostSimulationTools.Input))]
        [XmlElement(typeof(Models.PostSimulationTools.PredictedObserved))]
        [XmlElement(typeof(Models.PostSimulationTools.TimeSeriesStats))]
        [XmlElement(typeof(Models.PostSimulationTools.Probability))]
        [XmlElement(typeof(Models.PostSimulationTools.ExcelInput))]
        [XmlElement(typeof(Irrigation))]
        [XmlElement(typeof(Manager))]
        [XmlElement(typeof(MicroClimate))]
        [XmlElement(typeof(Arbitrator.Arbitrator))]
        [XmlElement(typeof(ArbitratorGod.ArbitratorGod))]
        [XmlElement(typeof(Operations))]
        [XmlElement(typeof(Models.Report.Report))]
        [XmlElement(typeof(Summary))]
        [XmlElement(typeof(NullSummary))]
        [XmlElement(typeof(Tests))]
        [XmlElement(typeof(Weather))]
        [XmlElement(typeof(ControlledEnvironment))]
        [XmlElement(typeof(Log))]
        [XmlElement(typeof(Models.Factorial.Experiment))]
        [XmlElement(typeof(Models.Factorial.Factors))]
        [XmlElement(typeof(Models.Factorial.Factor))]
        [XmlElement(typeof(Memo))]
        [XmlElement(typeof(Folder))]
        [XmlElement(typeof(Replacements))]
        [XmlElement(typeof(Soils.HydraulicProperties))]
        [XmlElement(typeof(Soils.MultiPoreWater))]
        [XmlElement(typeof(Soils.Water))]
        [XmlElement(typeof(Soils.SoilCrop))]
        [XmlElement(typeof(Soils.SoilCropOilPalm))]
        [XmlElement(typeof(Soils.SoilWater))]
        [XmlElement(typeof(Soils.SoilNitrogen))]
        [XmlElement(typeof(Soils.SoilOrganicMatter))]
        [XmlElement(typeof(Soils.Analysis))]
        [XmlElement(typeof(Soils.InitialWater))]
        [XmlElement(typeof(Soils.Phosphorus))]
        [XmlElement(typeof(Soils.Swim3))]
        [XmlElement(typeof(Soils.LayerStructure))]
        [XmlElement(typeof(Soils.SoilTemperature))]
        [XmlElement(typeof(Soils.SoilTemperature2))]
        [XmlElement(typeof(Soils.Arbitrator.SoilArbitrator))]
        [XmlElement(typeof(Soils.Sample))]
        [XmlElement(typeof(WaterModel.CNReductionForCover))]
        [XmlElement(typeof(WaterModel.CNReductionForTillage))]
        [XmlElement(typeof(WaterModel.EvaporationModel))]
        [XmlElement(typeof(WaterModel.LateralFlowModel))]
        [XmlElement(typeof(WaterModel.RunoffModel))]
        [XmlElement(typeof(WaterModel.SaturatedFlowModel))]
        [XmlElement(typeof(WaterModel.SoilModel))]
        [XmlElement(typeof(WaterModel.UnsaturatedFlowModel))]
        [XmlElement(typeof(WaterModel.WaterTableModel))]
        [XmlElement(typeof(Models.Sugarcane))]
        [XmlElement(typeof(Models.GrazPlan.Stock))]
        [XmlElement(typeof(Models.GrazPlan.Supplement))]
        [XmlElement(typeof(Models.PMF.OrganArbitrator))]
        [XmlElement(typeof(Models.PMF.Structure))]
        [XmlElement(typeof(Models.PMF.Biomass))]
        [XmlElement(typeof(Models.PMF.CompositeBiomass))]
        [XmlElement(typeof(Models.PMF.ArrayBiomass))]
        [XmlElement(typeof(Models.PMF.Organs.BelowGroundOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.GenericAboveGroundOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.GenericBelowGroundOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.GenericOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.HIReproductiveOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.Leaf))]
        [XmlElement(typeof(Models.PMF.Organs.LeafCohort))]
        [XmlElement(typeof(Models.PMF.Organs.Leaf.LeafCohortParameters))]
        [XmlElement(typeof(Models.PMF.Organs.Nodule))]
        [XmlElement(typeof(Models.PMF.Organs.ReproductiveOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.ReserveOrgan))]
        [XmlElement(typeof(Models.PMF.Organs.Root))]
        [XmlElement(typeof(Models.PMF.Organs.RootSWIM))]
        [XmlElement(typeof(Models.PMF.Organs.SimpleLeaf))]
        [XmlElement(typeof(Models.PMF.Organs.TreeCanopy))]
        [XmlElement(typeof(Models.PMF.Organs.SimpleRoot))]
        [XmlElement(typeof(Models.PMF.Phen.Phenology))]
        [XmlElement(typeof(Models.PMF.Phen.EmergingPhase))]
        [XmlElement(typeof(Models.PMF.Phen.EmergingPhase15))]
        [XmlElement(typeof(Models.PMF.Phen.EndPhase))]
        [XmlElement(typeof(Models.PMF.Phen.ExpressionPhase))]
        [XmlElement(typeof(Models.PMF.Phen.GenericPhase))]
        [XmlElement(typeof(Models.PMF.Phen.GerminatingPhase))]
        [XmlElement(typeof(Models.PMF.Phen.GotoPhase))]
        [XmlElement(typeof(Models.PMF.Phen.LeafAppearancePhase))]
        [XmlElement(typeof(Models.PMF.Phen.LeafDeathPhase))]
        [XmlElement(typeof(Models.PMF.Phen.MolecularPhenology))]
        [XmlElement(typeof(Models.PMF.Phen.NodeNumberPhase))]
        [XmlElement(typeof(Models.PMF.Phen.PhaseSetFunction))]
        [XmlElement(typeof(Models.PMF.Phen.Vernalisation))]
        [XmlElement(typeof(Models.PMF.Phen.VernalisationCW))]
        [XmlElement(typeof(Models.PMF.Phen.QualitativePPEffect))]
        [XmlElement(typeof(Models.PMF.Phen.ZadokPMF))]
        [XmlElement(typeof(Models.PMF.Functions.AccumulateFunction))]
        [XmlElement(typeof(Models.PMF.Functions.MovingAverageFunction))]
        [XmlElement(typeof(Models.PMF.Functions.AddFunction))]
        [XmlElement(typeof(Models.PMF.Functions.AgeCalculatorFunction))]
        [XmlElement(typeof(Models.PMF.Functions.AirTemperatureFunction))]
        [XmlElement(typeof(Models.PMF.Functions.BellCurveFunction))]
        [XmlElement(typeof(Models.PMF.Functions.Constant))]
        [XmlElement(typeof(Models.PMF.Functions.DeltaFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DivideFunction))]
        [XmlElement(typeof(Models.PMF.Functions.ExponentialFunction))]
        [XmlElement(typeof(Models.PMF.Functions.ExpressionFunction))]
        [XmlElement(typeof(Models.PMF.Functions.ExternalVariable))]
        [XmlElement(typeof(Models.PMF.Functions.HoldFunction))]
        [XmlElement(typeof(Models.PMF.Functions.InPhaseTtFunction))]
        [XmlElement(typeof(Models.PMF.Functions.LessThanFunction))]
        [XmlElement(typeof(Models.PMF.Functions.LinearInterpolationFunction))]
        [XmlElement(typeof(Models.PMF.Functions.MaximumFunction))]
        [XmlElement(typeof(Models.PMF.Functions.MinimumFunction))]
        [XmlElement(typeof(Models.PMF.Functions.MultiplyFunction))]
        [XmlElement(typeof(Models.PMF.Functions.OnEventFunction))]
        [XmlElement(typeof(Models.PMF.Functions.PhaseBasedSwitch))]
        [XmlElement(typeof(Models.PMF.Functions.PhaseLookup))]
        [XmlElement(typeof(Models.PMF.Functions.PhaseLookupValue))]
        [XmlElement(typeof(Models.PMF.Functions.PhotoperiodDeltaFunction))]
        [XmlElement(typeof(Models.PMF.Functions.PhotoperiodFunction))]
        [XmlElement(typeof(Models.PMF.Functions.PowerFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SigmoidFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SigmoidFunction2))]
        [XmlElement(typeof(Models.PMF.Functions.SoilTemperatureDepthFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SoilTemperatureFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SoilTemperatureWeightedFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SplineInterpolationFunction))]
        [XmlElement(typeof(Models.PMF.Functions.StageBasedInterpolation))]
        [XmlElement(typeof(Models.PMF.Functions.SubtractFunction))]
        [XmlElement(typeof(Models.PMF.Functions.VariableReference))]
        [XmlElement(typeof(Models.PMF.Functions.WeightedTemperatureFunction))]
        [XmlElement(typeof(Models.PMF.Functions.XYPairs))]
        [XmlElement(typeof(Models.PMF.Functions.Zadok))]
        [XmlElement(typeof(Models.PMF.Functions.SupplyFunctions.CanopyPhotosynthesis))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.AllometricDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.InternodeDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.PartitionFractionDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.PopulationBasedDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.PotentialSizeDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.RelativeGrowthRateDemandFunction))]
        [XmlElement(typeof(Models.PMF.Functions.DemandFunctions.FillingRateFunction))]
        [XmlElement(typeof(Models.PMF.Functions.StructureFunctions.HeightFunction))]
        [XmlElement(typeof(Models.PMF.Functions.StructureFunctions.InPhaseTemperatureFunction))]
        [XmlElement(typeof(Models.PMF.Functions.SupplyFunctions.RUECO2Function))]
        [XmlElement(typeof(Models.PMF.Functions.SupplyFunctions.RUEModel))]
        [XmlElement(typeof(Models.PMF.OldPlant.Plant15))]
        [XmlElement(typeof(Models.PMF.OldPlant.Environment))]
        [XmlElement(typeof(Models.PMF.OldPlant.GenericArbitratorXY))]
        [XmlElement(typeof(Models.PMF.OldPlant.Grain))]
        [XmlElement(typeof(Models.PMF.OldPlant.Leaf1))]
        [XmlElement(typeof(Models.PMF.OldPlant.LeafNumberPotential3))]
        [XmlElement(typeof(Models.PMF.OldPlant.NStress))]
        [XmlElement(typeof(Models.PMF.OldPlant.NUptake3))]
        [XmlElement(typeof(Models.PMF.OldPlant.PlantSpatial1))]
        [XmlElement(typeof(Models.PMF.OldPlant.Pod))]
        [XmlElement(typeof(Models.PMF.OldPlant.Population1))]
        [XmlElement(typeof(Models.PMF.OldPlant.PStress))]
        [XmlElement(typeof(Models.PMF.OldPlant.RadiationPartitioning))]
        [XmlElement(typeof(Models.PMF.OldPlant.Root1))]
        [XmlElement(typeof(Models.PMF.OldPlant.RUEModel1))]
        [XmlElement(typeof(Models.PMF.OldPlant.Stem1))]
        [XmlElement(typeof(Models.PMF.OldPlant.SWStress))]
        [XmlElement(typeof(Models.PMF.SimpleTree))]
        [XmlElement(typeof(Models.PMF.Cultivar))]
        [XmlElement(typeof(Models.PMF.CultivarFolder))]
        [XmlElement(typeof(Models.PMF.OrganBiomassRemovalType))]
        [XmlElement(typeof(Alias))]
        [XmlElement(typeof(Models.Zones.CircularZone))]
        [XmlElement(typeof(Models.Zones.RectangularZone))]
        [XmlElement(typeof(Models.Aqua.PondWater))]
        [XmlElement(typeof(Models.Aqua.FoodInPond))]
        [XmlElement(typeof(Models.Aqua.Prawns))]
        [XmlElement(typeof(Models.WholeFarm.Resources))]
        [XmlElement(typeof(Models.WholeFarm.Fodder))]
        [XmlElement(typeof(Models.WholeFarm.FodderType))]
        [XmlElement(typeof(Models.WholeFarm.FoodStore))]
        [XmlElement(typeof(Models.WholeFarm.FoodStoreType))]
        [XmlElement(typeof(Models.WholeFarm.LabourFamily))]
        [XmlElement(typeof(Models.WholeFarm.LabourFamilyType))]
        [XmlElement(typeof(Models.WholeFarm.LabourHired))]
        [XmlElement(typeof(Models.WholeFarm.LabourHiredType))]
        [XmlElement(typeof(Models.WholeFarm.Land))]
        [XmlElement(typeof(Models.WholeFarm.LandType))]
        [XmlElement(typeof(Models.WholeFarm.Pasture))]
        [XmlElement(typeof(Models.WholeFarm.PastureType))]
        [XmlElement(typeof(Models.WholeFarm.RuminantHerd))]
        [XmlElement(typeof(Models.WholeFarm.RuminantType))]
        [XmlElement(typeof(Models.WholeFarm.RuminantTypeCohort))]
        [XmlElement(typeof(Map))]
        public List<Model> Children { get; set; }

        /// <summary>
        /// Gets or sets the parent of the model.
        /// </summary>
        [XmlIgnore]
        public IModel Parent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a model is hidden from the user.
        /// </summary>
        [XmlIgnore]
        public bool IsHidden { get; set; }

        /// <summary>Writes documentation for this function by adding to the list of documentation tags.</summary>
        /// <param name="tags">The list of tags to add to.</param>
        /// <param name="headingLevel">The level (e.g. H2) of the headings.</param>
        /// <param name="indent">The level of indentation 1, 2, 3 etc.</param>
        public virtual void Document(List<AutoDocumentation.ITag> tags, int headingLevel, int indent)
        {
            // add a heading.
            tags.Add(new AutoDocumentation.Heading(Name, headingLevel));

            // write description of this class.
            AutoDocumentation.GetClassDescription(this, tags, indent);

            // write children.
            foreach (IModel child in Apsim.Children(this, typeof(IModel)))
                child.Document(tags, headingLevel + 1, indent);
        }

    }
}
