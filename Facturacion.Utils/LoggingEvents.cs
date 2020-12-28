using Microsoft.Extensions.Logging;

namespace Facturacion.Utils
{
    /**
     * | Code | Example           | Type            | 
     * |------|-------------------|-----------------|
     * | 1    | 10001 10002 10003 | Create          | 
     * | 2    | 20001 20002 20003 | Update          |
     * | 3    | 30001 30002 30003 | Delete          |
     * | 4    | 40001 40002 40003 | NotFound        |
     * | 5    | 50001 50002 50003 | Error           |
     * | 6    | 60001 60002 60003 | Change State    |
     * | 7    | 70001 70002 70003 | Get             |
     * | 8    | 80001 80002 80003 | Debug Validation|
     * | 9    | 90001 90002 90003 | Other           |
     */
    public static class LoggingEvents
    {
        #region Create
        //public static readonly EventId UploadPolicy = new EventId(10003, "Upload Pdf policy in blob storage");
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region NotFound
        #endregion

        #region Error

        #endregion

        #region ChangeState
        #endregion

        #region Get
        public static readonly EventId GetApiCoreLicensePlate = new(70001, "Get Api Core License Plate");
        public static readonly EventId GetPolicyByLicensePlate = new(70002, "Get Policy By License Plate");
        public static readonly EventId GetApiCoreClientCode = new(70003, "Get Api Core Client Code");

        public static readonly EventId GetPolicy = new(70004, "Get Pdf policy stream file");
        #endregion

        #region DebugValidation
        #endregion

        #region Other
        #endregion region
    }
}
