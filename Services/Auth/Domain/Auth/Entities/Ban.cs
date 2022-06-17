namespace RunSynopsis.Domain.Auth.Entities
{
    public class Ban
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long JudgeId { get; set; }

        public string Reason { get; set; }

        public DateTime GivenAt { get; set; } = DateTime.UtcNow;

        public DateTime? ExpiresAt { get; set; }

        public virtual bool IsExpired => ExpiresAt is not null && ExpiresAt < DateTime.UtcNow;

        public virtual User User { get; set; }

        public virtual User Judge { get; set; }

        public Ban()
        {
        }

        public Ban(User user, User judge, string reason, TimeSpan? duration)
        {
            UserId = user.Id;
            JudgeId = judge.Id;
            Reason = reason;
            ExpiresAt = DateTime.UtcNow + duration;
        }

        public Ban(long userId, long judgeId, string reason, TimeSpan? duration)
        {
            UserId = userId;
            JudgeId = judgeId;
            Reason = reason;
            ExpiresAt = DateTime.UtcNow + duration;
        }
    }
}