namespace LightsaberParry.Gameplay
{
    public interface IPredictionService
    {
        PredictionResult PredictCollision(SaberStateDto saber1, SaberStateDto saber2);
    }
}